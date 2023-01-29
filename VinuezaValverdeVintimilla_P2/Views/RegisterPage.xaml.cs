namespace VinuezaValverdeVintimilla_P2.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class RegisterPage : ContentPage
{
    public RegisterPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.RegisterViewModel(Navigation);
    }
}