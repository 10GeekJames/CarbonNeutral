// ag=yes
namespace LiveRoomApplication.Shared.Interfaces; 
public partial interface ILiveRoomDataService
{
    Task<List<LiveRoomSessionViewModel>?> LiveRoomSessionsGetAllAsync(LiveRoomSessionsGetAllRequest request);

}