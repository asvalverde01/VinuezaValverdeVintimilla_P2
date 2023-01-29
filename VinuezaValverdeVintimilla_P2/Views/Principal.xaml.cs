using Microsoft.Graph;

namespace VinuezaValverdeVintimilla_P2.Views;

public partial class Principal : ContentPage
{
    public Principal()
	{
		InitializeComponent();
        BindingContext = new ViewModels.LoginViewModel(Navigation);
    }
 
}