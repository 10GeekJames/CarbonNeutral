namespace WskApplication.Shared.Services;
public partial class WskHttpDataService : IWskDataService, IWskDataServiceNotAuthed
{
    protected readonly HttpClient _httpClient;

    public WskHttpDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
