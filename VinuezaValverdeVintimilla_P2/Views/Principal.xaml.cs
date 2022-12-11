using Microsoft.Graph;

namespace VinuezaValverdeVintimilla_P2.Views;

public partial class Principal : ContentPage
{
    private GraphService graphService;
    private User user;
    public Principal()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new InicioSesion());
    }

    private async void GetUserInfoBtn_Clicked(object sender, EventArgs e)
    {
        if (graphService == null)
        {
            graphService = new GraphService();
        }
        user = await graphService.GetMyDetailsAsync();
        //HelloLabel.Text = $"Hello, {user.DisplayName}!";
    }
}