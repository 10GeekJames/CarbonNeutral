namespace CarbonNeutral.BlazorClient;
public static class RegisterLazyServices
{
    public static void RegisterModules(WebAssemblyHostBuilder builder)
    {
        static void RegisterLazyServices(WebAssemblyHostBuilder builder)
        {
            RegisterLazyServicesWsk.RegisterModules(builder);
            //RegisterLazyServicesYmi();
            RegisterLazyServicesWsk.RegisterModules(builder);
        }
    }
}