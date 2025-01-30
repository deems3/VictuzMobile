using CommunityToolkit.Maui.Views;
using Auth0.OidcClient;
using VictuzMobile.App.Services;

namespace VictuzMobile.App.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView()
    {
        AvatarView avatarView = new()
        {
            Text = "PFP",
            BackgroundColor = Colors.Black,
            BorderColor = Color.FromArgb("#0F8390"),
            BorderWidth = 7,
            CornerRadius = 1000,
            HeightRequest = 300,
            WidthRequest = 300,
            ImageSource = "placeholderpfp.png"
        };
        Content = avatarView;

        InitializeComponent();
    }
    
    private async void OnDeletion_Clicked(object sender, EventArgs e)
    {
       bool confirm = await DisplayAlert("Bevestig account verwijdering", "Weet je zeker dat je je account wilt verwijderen?", "Ja", "Nee");

       if (confirm)
        {
            await DisplayAlert("ERROR", "Functionality not implemented yet", "OK");
        }
    }
    
    private void LogoutBtn_Clicked(object sender, EventArgs e)
    {
        var auth0Client = IPlatformApplication.Current?.Services.GetRequiredService<Auth0Client>();
        var authService = IPlatformApplication.Current?.Services.GetRequiredService<AuthService>();
        var mainTabbedPage = IPlatformApplication.Current?.Services.GetRequiredService<MainTabbedPage>();

        SecureStorageService.ClearCurrentUser();

        Navigation.PopToRootAsync();
        Window.Page = new MainPage(auth0Client, authService, mainTabbedPage);
    }

    private async void QRButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfileQRView());
    }
    private void ToggleVoornaam(object sender, EventArgs e)
    {
        VoornaamLabel.IsVisible = !VoornaamLabel.IsVisible;
        VoornaamEntry.IsVisible = !VoornaamEntry.IsVisible;

        if (!VoornaamLabel.IsVisible)
        {
            VoornaamEntry.Text = VoornaamLabel.Text; // Vul entry met bestaande tekst
        }
        else
        {
            VoornaamLabel.Text = VoornaamEntry.Text; // Update label na edit
        }
    }

    private void ToggleAchternaam(object sender, EventArgs e)
    {
        AchternaamLabel.IsVisible = !AchternaamLabel.IsVisible;
        AchternaamEntry.IsVisible = !AchternaamEntry.IsVisible;

        if (!AchternaamLabel.IsVisible)
        {
            AchternaamEntry.Text = AchternaamLabel.Text;
        }
        else
        {
            AchternaamLabel.Text = AchternaamEntry.Text;
        }
    }

    private void ToggleEmail(object sender, EventArgs e)
    {
        EmailLabel.IsVisible = !EmailLabel.IsVisible;
        EmailEntry.IsVisible = !EmailEntry.IsVisible;

        if (!EmailLabel.IsVisible)
        {
            EmailEntry.Text = EmailLabel.Text;
        }
        else
        {
            EmailLabel.Text = EmailEntry.Text;
        }
    }


}