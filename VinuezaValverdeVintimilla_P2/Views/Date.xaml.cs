using Newtonsoft.Json;
using System.Net;

namespace VinuezaValverdeVintimilla_P2.Views;

public partial class Date : ContentPage
{
    private string firstname;
    private string secondname;

    public Date()
    {
        InitializeComponent();
    }



    private async void Button_Clicked(object sender, EventArgs e)
    {
        string cadena1 = nombre1.Text;
        string cadena2 = nombre2.Text;
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://the-love-calculator.p.rapidapi.com/love-calculator?fname=" + cadena1 + "&sname=" + cadena2),
            Headers =
                {
                { "X-RapidAPI-Key", "501b276bd8mshd12800d0fc802eep19515ejsn5bd3f277b55f" },
                { "X-RapidAPI-Host", "the-love-calculator.p.rapidapi.com" },
                },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<Date>(content);
            ListaDemo.ItemsSource = new List<Date> { resultado };
        }
    }

}

