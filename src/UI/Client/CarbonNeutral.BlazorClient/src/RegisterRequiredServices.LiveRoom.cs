namespace CarbonNeutral.BlazorClient;
public static class RegisterRequiredLiveRoomModule
{
    public static void RegisterLiveRoomModule(this WebAssemblyHostBuilder builder)
    {
        var appSettings = builder.Configuration.Get<AppSettings>();

        // add the logged in users client endpoint for LiveRoom
        builder
            .Services
                .AddHttpClient("LiveRoomHttpClient",
                        client =>
                        {
                            client.BaseAddress = new Uri(appSettings.Endpoints.LiveRoomApiUrl);
                            client.Timeout = TimeSpan.FromSeconds(300);
                        }
                    ).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();                    

        // add the logged in users client endpoint for LiveRoom
        builder
            .Services
                .AddHttpClient("LiveRoomNotAuthedHttpClient",
                        client =>
                        {
                            client.BaseAddress = new Uri(appSettings.Endpoints.LiveRoomAdminApiUrl);
                            client.Timeout = TimeSpan.FromSeconds(300);
                        }
                    );

        // register the http client factory
        builder.Services.AddScoped<LiveRoomHttpClientFactory>();

        // allow the lazy modules an opportunity to participate in Dependency Injection
        builder.Services.AddLiveRoomHttpDataService();

        // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the authorized calls
        builder.Services.AddScoped<ILiveRoomDataService>(x => x
            .GetServices<LiveRoomHttpClientFactory>()
            .First().Create());

        builder.Services.AddScoped<ILiveRoomDataServiceNotAuthed>(x => x
            .GetServices<LiveRoomHttpClientFactory>()
            .First().CreateNotAuthed());
    }
}