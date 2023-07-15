namespace YmiApplication.Shared.Services;
public partial class YmiHttpDataService : IYmiDataService, IYmiDataServiceNotAuthed
{
    protected readonly HttpClient _httpClient;

    public YmiHttpDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
