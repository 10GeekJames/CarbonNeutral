namespace LiveRoomModuleClientServiceLoader
{
    public class LiveRoomHttpClientFactory
    {
        private readonly IServiceProvider _services;

        public LiveRoomHttpClientFactory(IServiceProvider services)
        {
            this._services = services;
        }

        public ILiveRoomDataService Create()
        {
            return new LiveRoomHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("LiveRoomHttpClient"));
        }
        public ILiveRoomDataServiceNotAuthed CreateNotAuthed()
        {
            return new LiveRoomHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("LiveRoomNotAuthedHttpClient"));
        }
    }
}