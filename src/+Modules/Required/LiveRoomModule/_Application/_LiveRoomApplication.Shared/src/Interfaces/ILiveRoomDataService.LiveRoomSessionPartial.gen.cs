// ag=yes
namespace LiveRoomApplication.Shared.Interfaces; 
public partial interface ILiveRoomDataService
{
    Task<LiveRoomSessionViewModel?> LiveRoomSessionCreateNewAsync(LiveRoomSessionCreateNewRequest request);
    Task<LiveRoomSessionViewModel?> LiveRoomSessionGetByIdAsync(LiveRoomSessionGetByIdRequest request);

}