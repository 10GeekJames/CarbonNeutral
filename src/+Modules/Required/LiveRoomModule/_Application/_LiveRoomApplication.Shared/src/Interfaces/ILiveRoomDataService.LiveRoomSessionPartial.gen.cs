// ag=yes
namespace LiveRoomApplication.Shared.Interfaces; 
public partial interface ILiveRoomDataService
{
    Task<LiveRoomSessionViewModel?> LiveRoomSessionCheckWordCoordsAsync(LiveRoomSessionCheckWordCoordsRequest request);
    Task<LiveRoomSessionViewModel?> LiveRoomSessionCreateNewAsync(LiveRoomSessionCreateNewRequest request);
    Task<LiveRoomSessionViewModel?> LiveRoomSessionGetByIdAsync(LiveRoomSessionGetByIdRequest request);
    Task<LiveRoomSessionViewModel?> LiveRoomSessionRecreateGridAsync(LiveRoomSessionRecreateGridRequest request);

}