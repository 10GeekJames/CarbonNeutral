namespace LiveRoomBlazorModule;
public class LiveRoomServiceWrapper
{
    public ILiveRoomDataService? _liveRoomService;
    public ILiveRoomDataService? ILiveRoomDataService { get => _liveRoomService; set { _liveRoomService = value; } }
}