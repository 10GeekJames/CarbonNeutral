// ag=yes
namespace LiveRoomApplication.Services; 
public partial class LiveRoomDirectDataService
{
    public async Task<List<LiveRoomSessionViewModel>?> LiveRoomSessionsGetAllAsync(LiveRoomSessionsGetAllRequest request)
    {
        var qry = _mapper.Map<LiveRoomSessionsGetAllQry>(request);
        return _mapper.Map<List<LiveRoomSessionViewModel>?>(await _mediator.Send(qry));
    }

}
