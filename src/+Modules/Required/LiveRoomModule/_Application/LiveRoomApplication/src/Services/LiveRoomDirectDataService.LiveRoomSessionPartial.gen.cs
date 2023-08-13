// ag=no ******
namespace LiveRoomApplication.Services; 
public partial class LiveRoomDirectDataService
{
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionCheckWordCoordsAsync(LiveRoomSessionCheckWordCoordsRequest request)
    {
        var qry = _mapper.Map<LiveRoomSessionCheckWordCoordsQry>(request);
        return _mapper.Map<LiveRoomSessionViewModel?>(await _mediator.Send(qry));
    }
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionCreateNewAsync(LiveRoomSessionCreateNewRequest request)
    {
        var cmd = _mapper.Map<LiveRoomSessionCreateNewCmd>(request);
        return _mapper.Map<LiveRoomSessionViewModel?>(await _mediator.Send(cmd));
    }
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionGetByIdAsync(LiveRoomSessionGetByIdRequest request)
    {
        var qry = _mapper.Map<LiveRoomSessionGetByIdQry>(request);
        return _mapper.Map<LiveRoomSessionViewModel?>(await _mediator.Send(qry));
    }
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionRecreateGridAsync(LiveRoomSessionRecreateGridRequest request)
    {
        var cmd = _mapper.Map<LiveRoomSessionRecreateGridCmd>(request);
        return _mapper.Map<LiveRoomSessionViewModel?>(await _mediator.Send(cmd));
    }

}
