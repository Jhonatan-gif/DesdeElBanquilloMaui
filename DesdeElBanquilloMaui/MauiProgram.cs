using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using DesdeElBanquilloMaui.Services;


namespace DesdeElBanquilloMaui

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

            builder.Services.AddHttpClient<ApiService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7135/api"); 
            });

            return builder.Build();

        }
    }
}
