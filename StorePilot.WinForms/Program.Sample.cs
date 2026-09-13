//using Microsoft.Extensions.DependencyInjection;using StorePilot.WinForms.Forms;using StorePilot.WinForms.Foundation;using StorePilot.WinForms.Theme;
//namespace StorePilot.WinForms;
//internal static class Program
//{
//    [STAThread]
//    static void Main()
//    {
//        ApplicationConfiguration.Initialize();

//        var services = new ServiceCollection();

//        services.AddSingleton<AppBrandSettingsStore>();

//        services.AddTransient<MainShellForm>();

//        using var provider = services.BuildServiceProvider();

//        var store = provider.GetRequiredService<AppBrandSettingsStore>();

//        var settings = store.Load();

//        AppTheme.Set(settings.Theme);

//        using (var splash = new SplashForm())
//            splash.ShowDialog();

//        if (!settings.IsConfigured)
//        {
//            using var setup = new FirstRunSetupForm(store);
//            if (setup.ShowDialog() != DialogResult.OK)
//                return;
//            settings = store.Load();
//            AppTheme.Set(settings.Theme);
//        }
//        Application.Run(provider.GetRequiredService<MainShellForm>());
//    }
//}
