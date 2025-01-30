using Auth0.OidcClient;
using Microsoft.Extensions.DependencyInjection;
using VictuzMobile.App.Services;

namespace VictuzMobile.App
{
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var auth0Client = _serviceProvider.GetRequiredService<Auth0Client>();
            var authService = _serviceProvider.GetRequiredService<AuthService>();
            //var mainTabbedPage = _serviceProvider.GetRequiredService<MainTabbedPage>();
            return new Window(new NavigationPage(new MainPage(auth0Client, authService)));
        }
    }
}