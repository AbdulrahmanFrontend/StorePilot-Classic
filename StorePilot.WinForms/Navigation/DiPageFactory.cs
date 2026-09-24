using System;
using System.Windows.Forms;
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
    {
        return _serviceProvider.GetRequiredService<TPage>();
    }
}
