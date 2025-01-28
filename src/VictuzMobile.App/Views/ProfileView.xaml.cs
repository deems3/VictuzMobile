using Auth0.OidcClient;
using VictuzMobile.App.Services;

namespace VictuzMobile.App.Views;

public partial class ProfileView : ContentPage
{
	public ProfileView()
	{
		InitializeComponent();
	}

    private void LogoutBtn_Clicked(object sender, EventArgs e)
    {
        var auth0Client = IPlatformApplication.Current?.Services.GetRequiredService<Auth0Client>();
        var authService = IPlatformApplication.Current?.Services.GetRequiredService<AuthService>();
        var mainTabbedPage = IPlatformApplication.Current?.Services.GetRequiredService<MainTabbedPage>();

        SecureStorageService.ClearCurrentUser();
		Window.Page = new MainPage(auth0Client, authService, mainTabbedPage);
    }
}