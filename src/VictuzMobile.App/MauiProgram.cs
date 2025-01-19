using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VictuzMobile.App.Helpers;
using VictuzMobile.DatabaseConfig;

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

            var host = builder.Build();

            using var scope = host.Services.CreateScope();

            // TODO, run migrations if any
            var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            var pendingMigrations = db.Database.GetPendingMigrations();

            if (pendingMigrations.Any())
            {
                    db.Database.Migrate();
            }

            return host;
        }
    }
}
