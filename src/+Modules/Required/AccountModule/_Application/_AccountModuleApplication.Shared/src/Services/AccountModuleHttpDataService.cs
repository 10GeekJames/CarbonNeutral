namespace AccountModuleApplication.Shared.Services;
public partial class AccountModuleHttpDataService : IAccountModuleDataService, IAccountModuleDataServiceNotAuthed
{
    protected readonly HttpClient _httpClient;

    public AccountModuleHttpDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
}
