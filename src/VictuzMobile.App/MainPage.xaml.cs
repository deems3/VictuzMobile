using Auth0.OidcClient;
using SQLiteBrowser;
using VictuzMobile.App.Helpers;
using VictuzMobile.App.Services;

namespace VictuzMobile.App
{
    public partial class MainPage : ContentPage
    {
        private readonly Auth0Client auth0Client;
        private readonly AuthService authService;

        public string? Username { get; set; }
        public string? Password { get; set; }

        public MainPage(Auth0Client client, AuthService authenticationService)
        {
            InitializeComponent();
            auth0Client = client;
            authService = authenticationService;
            BindingContext = this;

            CheckAuthenticationStatus();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var loginResult = await auth0Client.LoginAsync();

            if (!loginResult.IsError)
            {
                LoginView.IsVisible = false;
                HomeView.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
            }
        }

        private async void LoginUsernamePassword(object sender, EventArgs e)
        {
            var user = authService.Authenticate(Username, Password);

            if (user == null)
            {
                await DisplayAlert("Error", "unknown credentials", "Ok");
                return;
            }

            await SecureStorageService.StoreUser(user.Id);

            Window.Page = IPlatformApplication.Current.Services.GetRequiredService<MainTabbedPage>();
        }

        private async void CheckAuthenticationStatus()
        {
            bool isAuthenticated = await SecureStorageService.GetAuthenticationStatus();

            if (isAuthenticated)
            {
                Window.Page = IPlatformApplication.Current.Services.GetRequiredService<MainTabbedPage>();
            }
        }
    }

}
