using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using VictuzMobile.Models;

namespace VictuzMobile
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<BaseRepository<Activity>>();
            builder.Services.AddSingleton<BaseRepository<User>>();
            builder.Services.AddSingleton<BaseRepository<Category>>();
            builder.Services.AddSingleton<BaseRepository<Models.Location>>();
            builder.Services.AddSingleton<BaseRepository<Registration>>();
            builder.Services.AddSingleton<BaseRepository<Suggestion>>();

            return builder.Build();
        }
    }
}
