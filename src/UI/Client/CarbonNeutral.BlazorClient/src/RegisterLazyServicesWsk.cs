namespace CarbonNeutral.BlazorClient;
public static class RegisterLazyServicesWsk
{
    public static void RegisterWskModules(this WebAssemblyHostBuilder builder)
    {
        var appSettings = builder.Configuration.Get<AppSettings>();

        builder
            .Services
                .AddHttpClient("WskHttpClient",
                        client =>
                        {
                            client.BaseAddress = new Uri(appSettings.Endpoints.WskAdminApiUrl);
                            client.Timeout = TimeSpan.FromSeconds(300);
                        }

                    ).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

        // add the not logged in users client endpoint for Wsk
        builder
            .Services
                .AddHttpClient("WskNotAuthedHttpClient",
                    client =>
                        client.BaseAddress = new Uri(appSettings.Endpoints.WskApiUrl)
                );

        // register the http client factory
        builder.Services.AddScoped<WskHttpClientFactory>();

        // allow the lazy modules an opportunity to participate in Dependency Injection
        builder.Services.AddWskHttpDataService();

        // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the authorized calls
        builder.Services.AddScoped<IWskDataService>(x => x
            .GetServices<WskHttpClientFactory>()
            .First().Create());

        // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the not authorized calls
        builder.Services.AddScoped<IWskDataServiceNotAuthed>(x => x
            .GetServices<WskHttpClientFactory>()
            .First().CreateNotAuthed());

    }
}