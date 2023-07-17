namespace WskModuleClientServiceLoader
{
    public static class WskHttpClientFactoryExtension
    {
        public static void AddWskHttpDataService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IWskDataService, WskHttpDataService>();
            serviceCollection.AddSingleton<IWskDataServiceNotAuthed, WskHttpDataService>();
        }
    }
}