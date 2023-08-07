namespace CarbonNeutral.BlazorClient;
public static class RegisterLazyServices
{
    public static void RegisterLazyModules(this WebAssemblyHostBuilder builder)
    {
        builder.RegisterWskModules();    
    }
}