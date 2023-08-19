namespace CarbonNeutral.BlazorClient;
public static class RegisterRequiredAccountModule
{
    public static void RegisterAccountModule(this WebAssemblyHostBuilder builder)
    {
        var appSettings = builder.Configuration.Get<AppSettings>();

        // add the logged in users client endpoint for Account
        builder
            .Services
                .AddHttpClient("AccountModuleHttpClient",
                        client =>
                        {
                            client.BaseAddress = new Uri(appSettings.Endpoints.AccountApiUrl);
                            client.Timeout = TimeSpan.FromSeconds(300);
                        }
                    ).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();                    

        // add the logged in users client endpoint for Account
        builder
            .Services
                .AddHttpClient("AccountModuleNotAuthedHttpClient",
                        client =>
                        {
                            client.BaseAddress = new Uri(appSettings.Endpoints.AccountAdminApiUrl);
                            client.Timeout = TimeSpan.FromSeconds(300);
                        }
                    );

        // register the http client factory
        builder.Services.AddScoped<AccountModuleHttpClientFactory>();

        // allow the lazy modules an opportunity to participate in Dependency Injection
        builder.Services.AddAccountModuleHttpDataService();

        // setup the dependency injector to get a new instance of httpclient from the factory you registered above for the authorized calls
        builder.Services.AddScoped<IAccountModuleDataService>(x => x
            .GetServices<AccountModuleHttpClientFactory>()
            .First().Create());

        builder.Services.AddScoped<IAccountModuleDataServiceNotAuthed>(x => x
            .GetServices<AccountModuleHttpClientFactory>()
            .First().CreateNotAuthed());
    }
}