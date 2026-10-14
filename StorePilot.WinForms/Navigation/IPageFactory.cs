namespace StorePilot.WinForms.Navigation;

public interface IPageFactory
{
    TPage Create<TPage>() where TPage : UserControl;
}
