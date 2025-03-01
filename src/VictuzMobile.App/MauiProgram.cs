﻿using Auth0.OidcClient;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VictuzMobile.App.Helpers;
using VictuzMobile.App.Services;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig;
using ZXing.Net.Maui.Controls;
using Plugin.LocalNotification;

namespace VictuzMobile.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBarcodeReader()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var connectionDb = $"Filename={DatabaseHelpers.GetDatabasePath("mobile_app_casus.db")}";

            builder.Services.AddDbContext<DatabaseContext>(
                options => options.UseSqlite(connectionDb));

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddScoped<AuthService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageView>();
            builder.Services.AddTransient<ProfileView>();
            builder.Services.AddTransient<SettingsView>();
            builder.Services.AddTransient<ActivitiesView>();
            builder.Services.AddTransient<MainTabbedPage>();

            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "dev-awmp00p4ykz2jar7.us.auth0.com",
                ClientId = "3IdWRn9a92mNcsNKn7pPCBBOxoOJ3ohK",
                RedirectUri = "myapp://callback/",
                PostLogoutRedirectUri = "myapp://callback/",
                Scope = "openid profile email"
            }));


            var app = builder.Build();

            using (var scope = app.Services.CreateScope()) {

                var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var pendingMigrations = db.Database.GetPendingMigrations();

                if (pendingMigrations.Any())
                {
                    db.Database.Migrate();
                }
            }

            return app;
        }
    }
}
