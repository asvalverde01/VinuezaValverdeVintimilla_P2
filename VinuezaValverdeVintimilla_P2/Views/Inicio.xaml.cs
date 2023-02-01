
using Newtonsoft.Json;

namespace VinuezaValverdeVintimilla_P2.Views;

public partial class Inicio : ContentPage
{
    private readonly IMediaPicker mediaPicker;

    public Inicio(IMediaPicker mediaPicker)
	{
		InitializeComponent();
        GetProfileInfo();

        BindingContext = new Models.AllNotes();
        this.mediaPicker = mediaPicker;
    }

    private void GetProfileInfo()
    {
        var userInfo = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("FreshFirebaseToken", ""));
        //UserEmail.Text = userInfo.User.Email;
    }

    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
    void OnTextChanged(object sender, EventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        //searchResults.ItemsSource = AllNotes.GetSearchResults(searchBar.Text);
    }

    private async void Cam_Clicked(object sender, EventArgs e)
    {
        if(mediaPicker.IsCaptureSupported)
        {
            FileResult photo = await mediaPicker.CapturePhotoAsync();
            if(photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using Stream source = await photo.OpenReadAsync();
                using FileStream localFile = File.OpenWrite(localFilePath);
                await source.CopyToAsync(localFile);
            }
        }
    }

    private async void Date_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Date());
    }
}