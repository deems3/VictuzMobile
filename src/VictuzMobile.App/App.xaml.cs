using Auth0.OidcClient;
using VictuzMobile.App.Services;

namespace VictuzMobile.App
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var auth0Client = serviceProvider.GetRequiredService<Auth0Client>();
            var authService = serviceProvider.GetRequiredService<AuthService>();
            var mainTabbedPage = serviceProvider.GetRequiredService<MainTabbedPage>();
            MainPage = new NavigationPage(new MainPage(auth0Client, authService, mainTabbedPage));
        }
    }
}