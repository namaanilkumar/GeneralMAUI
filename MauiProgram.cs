using GeneralMAUI.Services;
using GeneralMAUI.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace GeneralMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            // Register HttpClient with base address
            builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7203"); // real API base
            });

            builder.Services.AddSingleton<DatabaseService>();

            return builder.Build();
        }
    }
}
