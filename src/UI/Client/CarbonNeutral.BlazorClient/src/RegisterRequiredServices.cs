namespace CarbonNeutral.BlazorClient;
public static class RegisterRequiredServices
{
    public static void RegisterRequiredModules(this WebAssemblyHostBuilder builder)
    {
        builder.RegisterAccountModule();
        builder.RegisterLiveRoomModule();
    }
}
