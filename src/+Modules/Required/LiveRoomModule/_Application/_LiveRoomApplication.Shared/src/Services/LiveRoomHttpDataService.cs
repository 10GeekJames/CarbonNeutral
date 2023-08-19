namespace LiveRoomApplication.Shared.Services;
public partial class LiveRoomHttpDataService : ILiveRoomDataService, ILiveRoomDataServiceNotAuthed
{
    protected readonly HttpClient _httpClient;

    public LiveRoomHttpDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
