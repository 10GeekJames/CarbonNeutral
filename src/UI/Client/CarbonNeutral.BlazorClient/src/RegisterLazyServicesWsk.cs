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
            
        }        
    }
}