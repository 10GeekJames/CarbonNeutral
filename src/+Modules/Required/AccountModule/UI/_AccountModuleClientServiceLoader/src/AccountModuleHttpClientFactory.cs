namespace AccountModuleClientServiceLoader;
public class AccountModuleHttpClientFactory
{
    private readonly IServiceProvider _services;

    public AccountModuleHttpClientFactory(IServiceProvider services)
    {
        this._services = services;
    }

    public IAccountModuleDataService Create()
    {
        return new AccountModuleHttpDataService(this._services.GetRequiredService<IHttpClientFactory>().CreateClient("AccountModuleHttpClient"));
    }    
}
