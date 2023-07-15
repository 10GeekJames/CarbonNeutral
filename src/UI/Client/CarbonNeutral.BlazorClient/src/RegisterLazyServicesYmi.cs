namespace CarbonNeutral.BlazorClient;
public static class RegisterLazyServicesYmi
{
    public static void RegisterModules(WebAssemblyHostBuilder builder)
    {
        RegisterYmiLazyServices(builder);

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