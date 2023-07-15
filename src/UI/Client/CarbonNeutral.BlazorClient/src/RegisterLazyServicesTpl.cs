namespace CarbonNeutral.BlazorClient;
public static class RegisterLazyServicesWsk
{
    public static void RegisterModules(WebAssemblyHostBuilder builder)
    {
        RegisterWskLazyServices(builder);

        static void RegisterWskLazyServices(WebAssemblyHostBuilder builder)
        {
            var appSettings = builder.Configuration.Get<AppSettings>();

            // add the logged in users client endpoint for Wsk
            builder
                .Services
                    .AddHttpClient("WskModuleHttpClient",
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
            builder.Services.AddScoped<WskModuleHttpClientFactory>();

            // allow the lazy modules an opportunity to participate in Dependency Injection
            builder.Services.AddWskModuleHttpDataService();

            // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the authorized calls
            builder.Services.AddScoped<IWskDataService>(x => x
                .GetServices<WskModuleHttpClientFactory>()
                .First().Create());

            // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the not authorized calls
            builder.Services.AddScoped<IWskDataService>(x => x
                .GetServices<WskModuleHttpClientFactory>()
                .First().CreateNotAuthed());
        }

        static void RegisterYmiLazyServices(WebAssemblyHostBuilder builder)
        {
            var appSettings = builder.Configuration.Get<AppSettings>();

           /*  // add the logged in users client endpoint for Ymi
            builder
                .Services
                    .AddHttpClient("YmiModuleHttpClient",
                        client =>
                        {
                            client.BaseAddress = new Uri(appSettings.Endpoints.YmiAdminApiUrl);
                            client.Timeout = TimeSpan.FromSeconds(300);
                        }

                    ).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

            // add the not logged in users client endpoint for Ymi
            builder
                .Services
                    .AddHttpClient("YmiNotAuthedHttpClient",
                        client =>
                            client.BaseAddress = new Uri(appSettings.Endpoints.YmiApiUrl)
                    );

            // register the http client factory
            builder.Services.AddScoped<YmiModuleHttpClientFactory>();

            // allow the lazy modules an opportunity to participate in Dependency Injection
            builder.Services.AddYmiModuleHttpDataService();

            // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the authorized calls
            builder.Services.AddScoped<IYmiDataService>(x => x
                .GetServices<YmiModuleHttpClientFactory>()
                .First().Create());

            // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the not authorized calls
            builder.Services.AddScoped<IYmiDataService>(x => x
                .GetServices<YmiModuleHttpClientFactory>()
                .First().CreateNotAuthed()); */

        }

        
    }
}