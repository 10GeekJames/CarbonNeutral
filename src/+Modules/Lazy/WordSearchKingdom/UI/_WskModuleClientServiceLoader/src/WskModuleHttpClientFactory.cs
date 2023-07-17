namespace WskModuleClientServiceLoader
{
    public class WskHttpClientFactory
    {
        private readonly IServiceProvider _services;

        public WskHttpClientFactory(IServiceProvider services)
        {
            this._services = services;
        }

        public IWskDataService Create()
        {
            return new WskHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("WskHttpClient"));
        }
        public IWskDataServiceNotAuthed CreateNotAuthed()
        {
            return new WskHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("WskNotAuthedHttpClient"));
        }
    }
}