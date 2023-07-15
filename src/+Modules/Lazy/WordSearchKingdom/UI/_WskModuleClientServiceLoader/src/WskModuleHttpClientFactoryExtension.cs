namespace WskModuleClientServiceLoader
{
    public static class WskModuleHttpClientFactoryExtension
    {
        public static void AddWskModuleHttpDataService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IWskDataService, WskModuleHttpDataService>();
            serviceCollection.AddSingleton<IWskDataServiceNotAuthed, WskModuleHttpDataService>();
        }
    }
}