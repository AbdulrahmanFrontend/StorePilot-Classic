using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StorePilot.Application.Interfaces;
using StorePilot.Application.Services;
using StorePilot.Application.Validators.ProductGroups;
using StorePilot.Application.Validators.Products;
using StorePilot.Application.Validators.Units;
using StorePilot.Infrastructure.Backup;
using StorePilot.Infrastructure.Data;
using StorePilot.Infrastructure.Data.Database;
using StorePilot.Infrastructure.Storage;
using StorePilot.WinForms.Forms;
using StorePilot.WinForms.Foundation;
using StorePilot.WinForms.Navigation;
using StorePilot.WinForms.Pages;
using StorePilot.WinForms.Theme;
using StorePilot.WinForms.ViewModels;

namespace StorePilot.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        ApplicationConfiguration.Initialize();

        var paths = new StorePilotPaths();

        paths.EnsureDirectories(); // ضمان وجود المجلدات أولاً

        // 1. إعداد Serilog وكتابة السجلات داخل مجلد AppData الخاص بالتطبيق
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", 
            Serilog.Events.LogEventLevel.Warning) 
            // تقليل ضوضاء مايكروسوفت
            .WriteTo.File(
                path: Path.Combine(paths.RootDirectory, 
                "Logs", 
                "storepilot-log-.txt"),
                rollingInterval: RollingInterval.Day,
                outputTemplate: 
                "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}" +
                " [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        // 1. التقاط أخطاء واجهة المستخدم غير المعالجة
        System.Windows.Forms.Application.ThreadException += (sender, args) =>
        {
            Log.Fatal(args.Exception, "حدث خطأ غير متوقع في واجهة المستخدم!");

            // سحر الحل: إجبار Serilog على حفظ الكتابة في الملف فوراً قبل إغلاق النافذة
            Log.CloseAndFlush();

            MessageBox.Show(
                $"خطأ فادح:\n{args.Exception.Message}", 
                "خطأ", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        };

        // 2. التقاط الأخطاء الفادحة في خيوط الخلفية
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            if (args.ExceptionObject is Exception ex)
            {
                Log.Fatal(ex, "حدث خطأ فادح غير معالج في النظام!");

                // حفظ السجلات فوراً قبل موت العملية بالكامل
                Log.CloseAndFlush();
            }
        };
        try
        {
            Log.Information("--- جاري بدء تشغيل تطبيق StorePilot ---");

            var settingsStore = new AppBrandSettingsStore(
                paths.SettingsFilePath,
                paths.BrandingDirectory);

            var services = new ServiceCollection();

            // حقن Serilog ليكون متاحاً عبر ILogger<T> في كل السيرفسز
            services.AddLogging(loggingBuilder => 
                loggingBuilder.AddSerilog(dispose: true));

            ConfigureServices(services, paths, settingsStore);

            using var serviceProvider = services.BuildServiceProvider();

            InitializeDatabaseAsync(serviceProvider)
                .GetAwaiter()
                .GetResult();

            if (!RunStartupFlow(serviceProvider, paths))
                return;

            System.Windows.Forms.Application.Run(
                serviceProvider.GetRequiredService<MainShellForm>());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "فشل التطبيق في الإقلاع بشكل غير متوقع!");

            MessageBox.Show(
                $"حدث خطأ فادح أثناء بدء التشغيل:\n{ex.Message}", "خطأ", 
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            Log.CloseAndFlush(); 
            // لضمان كتابة وحفظ جميع السجلات قبل الإغلاق التام
        }
    }

    private static void ServicesRegistration(IServiceCollection services)
    {
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<IProductGroupService, ProductGroupService>();
    }

    private static void ValidatorsRegistration(IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CreateUnitDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateUnitDtoValidator).Assembly);

        services.AddValidatorsFromAssembly(typeof(CreateProductGroupDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateProductGroupDtoValidator).Assembly);

        services.AddValidatorsFromAssembly(typeof(CreateProductDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateProductDtoValidator).Assembly);
    }

    private static void ViewModelsRegistration(IServiceCollection services)
    {
        services.AddTransient<UnitsViewModel>();
        services.AddTransient<GroupsViewModel>();
        services.AddTransient<DashboardViewModel>();
    }

    private static void PagesRegistration(IServiceCollection services)
    {
        services.AddTransient<DashboardPage>();
        services.AddTransient<SettingsPage>();

        services.AddTransient<UnitsPage>();
        services.AddTransient<GroupsPage>();
    }

    /// <summary>
    /// Registers application services in the Dependency Injection
    /// container.
    /// </summary>
    private static void ConfigureServices(
        IServiceCollection services,
        StorePilotPaths paths,
        AppBrandSettingsStore settingsStore)
    {
        services.AddSingleton(paths);
        services.AddSingleton(settingsStore);

        services.AddDbContext<StorePilotDbContext>(
            options =>
            {
                options.UseSqlite(
                    $"Data Source={paths.DatabaseFilePath}");
            });

        services.AddScoped<IAppDbContext, StorePilotDbContext>();

        services.AddSingleton<IBackupService>(
            _ => new FileBackupService(
                paths.DatabaseFilePath,
                paths.BackupDirectory));

        services.AddSingleton<IPageFactory, DiPageFactory>();

        ServicesRegistration(services);
        
        ValidatorsRegistration(services);

        ViewModelsRegistration(services);

        PagesRegistration(services);

        services.AddTransient<MainShellForm>();
    }

    /// <summary>
    /// Creates a DbContext scope and initializes the database.
    /// </summary>
    private static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
    {
        // --------------------------------------------------------
        // Create a scope
        // --------------------------------------------------------
        //
        // DbContext is registered as Scoped.
        // Therefore we create a scope before resolving it.
        //
        using var scope = serviceProvider.CreateScope();


        // --------------------------------------------------------
        // Resolve DbContext
        // --------------------------------------------------------
        //
        // Dependency Injection creates the DbContext for us
        // using the SQLite configuration registered above.
        //
        var dbContext =
            scope.ServiceProvider
                .GetRequiredService<StorePilotDbContext>();


        // --------------------------------------------------------
        // Initialize database schema
        // --------------------------------------------------------
        //
        // DatabaseInitializer is responsible ONLY for preparing
        // the database structure.
        //
        // It does not contain business logic.
        //
        await DatabaseInitializer.InitializeAsync(dbContext);
    }

    private static bool RunStartupFlow(
        IServiceProvider serviceProvider,
        StorePilotPaths paths)
    {
        var settingsStore =
            serviceProvider.GetRequiredService<AppBrandSettingsStore>();

        var settings = settingsStore.Load();

        AppTheme.Set(settings.Theme);

        using (var splash = new SplashForm(paths))
        {
            splash.ShowDialog();
        }

        if (!settings.IsConfigured)
        {
            using var setupForm =
                new FirstRunSetupForm(settingsStore);

            return setupForm.ShowDialog() == DialogResult.OK;
        }

        return true;
    }
}
