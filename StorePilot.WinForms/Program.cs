using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StorePilot.Infrastructure.Data;
using StorePilot.Infrastructure.Data.Database;

namespace StorePilot.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // --------------------------------------------------------
            // 1. Initialize WinForms
            // --------------------------------------------------------
            //
            // This configures the default WinForms environment,
            // including high DPI support, fonts, and other
            // framework-level settings.
            //
            ApplicationConfiguration.Initialize();


            // --------------------------------------------------------
            // 2. Configure application services
            // --------------------------------------------------------
            //
            // We use Microsoft's Dependency Injection container even
            // though this is a Desktop application.
            //
            // This gives us a clean way to create and manage:
            //
            // - DbContext
            // - Application services
            // - Repositories (if needed later)
            // - Other infrastructure services
            //
            var services = new ServiceCollection();

            ConfigureServices(services);


            // --------------------------------------------------------
            // 3. Build the Dependency Injection container
            // --------------------------------------------------------
            //
            // ServiceProvider is responsible for creating the objects
            // registered above and resolving their dependencies.
            //
            using var serviceProvider = services.BuildServiceProvider();


            // --------------------------------------------------------
            // 4. Initialize the database before starting the UI
            // --------------------------------------------------------
            //
            // This must happen before MainForm is created because
            // the application expects the database to be ready.
            //
            await InitializeDatabaseAsync(serviceProvider);


            //await TestDatabaseAsync(serviceProvider);

            // --------------------------------------------------------
            // 5. Start the WinForms application
            // --------------------------------------------------------
            //
            // Only after successful database initialization do we
            // open the main window.
            //
            var mainForm = serviceProvider.GetRequiredService<frmSplash>();

            Application.Run(mainForm);
        }


        //private static async Task TestDatabaseAsync(IServiceProvider serviceProvider)
        //{
        //    using var scope =
        //        serviceProvider.CreateScope();

        //    var dbContext =
        //        scope.ServiceProvider
        //            .GetRequiredService<StorePilotDbContext>();

        //    var productCount = await dbContext.Products.CountAsync();

        //    MessageBox.Show(
        //        $"EF Core connection successful.\n\n" +
        //        $"Products count: {productCount}",
        //        "StorePilot",
        //        MessageBoxButtons.OK,
        //        MessageBoxIcon.Information);
        //}


        /// <summary>
        /// Registers application services in the Dependency Injection
        /// container.
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            // --------------------------------------------------------
            // Database
            // --------------------------------------------------------
            //
            // Replace the path with the final database location
            // chosen for StorePilot.
            //
            var databasePath = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "StorePilot",
                "StorePilot.db");


            // Make sure the directory exists before SQLite tries
            // to create the database file.
            Directory.CreateDirectory(
                Path.GetDirectoryName(databasePath)!);


            var connectionString =
                $"Data Source={databasePath}";


            // Register EF Core DbContext.
            //
            // AddDbContext registers the DbContext with a scoped
            // lifetime, which is appropriate for EF Core operations.
            services.AddDbContext<StorePilotDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            // --------------------------------------------------------
            // Forms
            // --------------------------------------------------------

            services.AddTransient<frmSplash>();
        }


        /// <summary>
        /// Creates a DbContext scope and initializes the database.
        /// </summary>
        private static async Task InitializeDatabaseAsync(
            IServiceProvider serviceProvider)
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
    }
}