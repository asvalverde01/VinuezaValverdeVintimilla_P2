using Newtonsoft.Json;

namespace VinuezaValverdeVintimilla_P2.Views;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
        var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
        UserEmail.Text = userInfo.User.Email;
    }
}