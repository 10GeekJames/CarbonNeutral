namespace WskApplication.Shared.Services;
public partial class WskModuleHttpDataService : IWskDataService, IWskDataServiceNotAuthed
{
    protected readonly HttpClient _httpClient;

    public WskModuleHttpDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
