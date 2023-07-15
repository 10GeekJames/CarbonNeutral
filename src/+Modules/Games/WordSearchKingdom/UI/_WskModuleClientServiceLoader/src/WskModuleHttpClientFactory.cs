namespace WskModuleClientServiceLoader
{
    public class WskModuleHttpClientFactory
    {
        private readonly IServiceProvider _services;

        public WskModuleHttpClientFactory(IServiceProvider services)
        {
            this._services = services;
        }

        public IWskDataService Create()
        {
            return new WskModuleHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("WskModuleHttpClient"));
        }
        public IWskDataServiceNotAuthed CreateNotAuthed()
        {
            return new WskModuleHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("WskNotAuthedHttpClient"));
        }
    }
}