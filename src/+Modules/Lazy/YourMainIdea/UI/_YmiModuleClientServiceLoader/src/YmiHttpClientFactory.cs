namespace YmiModuleClientServiceLoader
{
    public class YmiHttpClientFactory
    {
        private readonly IServiceProvider _services;

        public YmiHttpClientFactory(IServiceProvider services)
        {
            this._services = services;
        }

        public IYmiDataService Create()
        {
            return new YmiHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("YmiHttpClient"));
        }
        public IYmiDataServiceNotAuthed CreateNotAuthed()
        {
            return new YmiHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("YmiNotAuthedHttpClient"));
        }
    }
}