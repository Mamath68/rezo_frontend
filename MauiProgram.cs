using System.Text.Json;
using Microsoft.Extensions.Logging;
using Radzen;
using RezoFrontend.Models;
using RezoFrontend.Service;

namespace RezoFrontend;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.Services.AddSingleton(new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });
        builder.Services.AddScoped(sp =>
        {
            var client = new HttpClient();
#if ANDROID
    client.BaseAddress = new Uri("http://10.0.2.2:8080/api/");
#else
            client.BaseAddress = new Uri("http://localhost:8080/api/");
#endif
            return client;
        });
        builder.Services.AddRadzenComponents();
        builder.Services.AddSingleton<TitleService>();
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddScoped<CalendarViewModel>();


        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}