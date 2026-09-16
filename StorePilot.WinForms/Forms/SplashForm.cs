using StorePilot.WinForms.Theme;

namespace StorePilot.WinForms.Forms;

public partial class SplashForm : Form
{
    private readonly System.Windows.Forms.Timer _fadeInTimer;
    private readonly System.Windows.Forms.Timer _displayTimer;

    private bool _closing;

    public SplashForm()
    {
        InitializeComponent();

        _fadeInTimer = new System.Windows.Forms.Timer
        {
            Interval = 20
        };

        _displayTimer = new System.Windows.Forms.Timer
        {
            Interval = 1500
        };

        _fadeInTimer.Tick += FadeInTimer_Tick;
        _displayTimer.Tick += DisplayTimer_Tick;
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);

        AppTheme.Apply(this);

        Opacity = 0;

        _fadeInTimer.Start();
        _displayTimer.Start();
    }

    private void FadeInTimer_Tick(
        object? sender,
        EventArgs e)
    {
        Opacity = Math.Min(
            1,
            Opacity + 0.08);

        if (Opacity >= 1)
            _fadeInTimer.Stop();
    }

    private void DisplayTimer_Tick(
        object? sender,
        EventArgs e)
    {
        if (_closing)
            return;

        _closing = true;

        _displayTimer.Stop();
        _fadeInTimer.Stop();

        var fadeOutTimer = new System.Windows.Forms.Timer
        {
            Interval = 20
        };

        fadeOutTimer.Tick += (_, _) =>
        {
            Opacity -= 0.08;

            if (Opacity <= 0)
            {
                fadeOutTimer.Stop();
                fadeOutTimer.Dispose();

                Close();
            }
        };

        fadeOutTimer.Start();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _fadeInTimer.Stop();
        _displayTimer.Stop();

        _fadeInTimer.Dispose();
        _displayTimer.Dispose();

        base.OnFormClosed(e);
    }
}
