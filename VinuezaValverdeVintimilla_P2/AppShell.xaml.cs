
using VinuezaValverdeVintimilla_P2.Views;

namespace VinuezaValverdeVintimilla_P2;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
    }
}
