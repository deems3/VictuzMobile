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
        private readonly MainTabbedPage mainTabbedPage;

        public string Username { get; set; }
        public string Password { get; set; }

        public MainPage(Auth0Client client, AuthService authenticationService, MainTabbedPage page)
        {
            InitializeComponent();
            auth0Client = client;
            authService = authenticationService;
            mainTabbedPage = page;
            SecureStorageService.ClearCurrentUserId();
            BindingContext = this;
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

        private async void OpenDbBrowser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatabaseBrowserPage(DatabaseHelpers.GetDatabasePath("mobile-app-casus.db")));
        }

        private void TestButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = mainTabbedPage;
        }

        private async void LoginUsernamePassword(object sender, EventArgs e)
        {
            var user = authService.Authenticate(Username, Password);

            if (user == null)
            {
                await DisplayAlert("Error", "unknown credentials", "Ok");
                return;
            }

            await SecureStorageService.StoreUserId(user.Id);

            Application.Current.MainPage = mainTabbedPage;
        }
    }

}
