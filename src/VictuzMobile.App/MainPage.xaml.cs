using Auth0.OidcClient;
using SQLiteBrowser;
using VictuzMobile.App.Helpers;

namespace VictuzMobile.App
{
    public partial class MainPage : ContentPage
    {
        private readonly Auth0Client auth0Client;

        public MainPage(Auth0Client client)
        {
            InitializeComponent();
            auth0Client = client;
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
            Application.Current.MainPage = new MainTabbedPage();
        }
    }

}
