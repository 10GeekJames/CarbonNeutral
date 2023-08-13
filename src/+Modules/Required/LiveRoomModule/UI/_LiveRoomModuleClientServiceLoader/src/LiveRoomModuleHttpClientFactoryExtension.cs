namespace LiveRoomModuleClientServiceLoader
{
    public static class LiveRoomHttpClientFactoryExtension
    {
        public static void AddLiveRoomHttpDataService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILiveRoomDataService, LiveRoomHttpDataService>();
            serviceCollection.AddSingleton<ILiveRoomDataServiceNotAuthed, LiveRoomHttpDataService>();
        }
    }
}