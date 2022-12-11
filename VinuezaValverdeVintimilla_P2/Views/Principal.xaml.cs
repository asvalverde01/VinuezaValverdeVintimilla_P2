namespace VinuezaValverdeVintimilla_P2.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new InicioSesion());
    }
}