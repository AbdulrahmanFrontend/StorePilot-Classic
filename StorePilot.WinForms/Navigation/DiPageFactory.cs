using Microsoft.Extensions.DependencyInjection;

namespace StorePilot.WinForms.Navigation;

public sealed class DiPageFactory : IPageFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DiPageFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TPage Create<TPage>() where TPage : UserControl
        => _serviceProvider.GetRequiredService<TPage>();
}
