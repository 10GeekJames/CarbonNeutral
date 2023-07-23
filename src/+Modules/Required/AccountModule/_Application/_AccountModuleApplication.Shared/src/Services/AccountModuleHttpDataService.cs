namespace AccountModuleApplication.Shared.Services;
public partial class AccountModuleHttpDataService : IAccountModuleDataService
{
    protected readonly HttpClient _httpClient;

    public AccountModuleHttpDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
}
