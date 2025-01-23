using Auth0.OidcClient;

namespace VictuzMobile.App
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var auth0Client = serviceProvider.GetRequiredService<Auth0Client>();
            MainPage = new NavigationPage(new MainPage(auth0Client));
        }
    }
}