namespace VinuezaValverdeVintimilla_P2.Views;

public partial class InicioSesion : ContentPage
{
	public InicioSesion()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Contraseņa());
    }
    
	private void OnCounterClicked1(object sender, EventArgs e)
	{
        
        Navigation.PushAsync(new AppShell());
        Application.Current.MainPage = new AppShell();
    }
}