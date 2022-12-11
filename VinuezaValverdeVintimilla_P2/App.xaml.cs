namespace VinuezaValverdeVintimilla_P2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		var navPage= new NavigationPage(new Views.Principal());
		navPage.BarBackground = Colors.Moccasin;
		navPage.BarTextColor = Colors.Black;
		MainPage = navPage;
	}
}
