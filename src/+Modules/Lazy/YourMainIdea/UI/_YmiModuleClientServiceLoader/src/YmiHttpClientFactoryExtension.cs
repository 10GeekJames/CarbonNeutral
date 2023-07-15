namespace YmiModuleClientServiceLoader
{
    public static class YmiHttpClientFactoryExtension
    {
        public static void AddYmiHttpDataService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IYmiDataService, YmiHttpDataService>();
            serviceCollection.AddSingleton<IYmiDataServiceNotAuthed, YmiHttpDataService>();
        }
    }
}