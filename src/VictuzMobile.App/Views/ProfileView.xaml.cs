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
    
    private void OnDeletion_Clicked(object sender, EventArgs e)
    {
       DisplayAlert("Bevestig account verwijdering", "Weet je zeker dat je je account wilt verwijderen?", "Ja", "Nee");
    }
    
    private void LogoutBtn_Clicked(object sender, EventArgs e)
    {
        var auth0Client = IPlatformApplication.Current?.Services.GetRequiredService<Auth0Client>();
        var authService = IPlatformApplication.Current?.Services.GetRequiredService<AuthService>();
        var mainTabbedPage = IPlatformApplication.Current?.Services.GetRequiredService<MainTabbedPage>();

        SecureStorageService.ClearCurrentUser();
		    Window.Page = new MainPage(auth0Client, authService, mainTabbedPage);
    }

    private async void QRButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfileQRView());
    }
}