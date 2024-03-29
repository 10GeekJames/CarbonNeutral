// ag=yes
namespace WskApplication.Services; 
public partial class WskDirectDataService
{
    public async Task<GameViewModel?> GameCheckWordCoordsAsync(GameCheckWordCoordsRequest request)
    {
        var cmd = _mapper.Map<GameCheckWordCoordsCmd>(request);
        return _mapper.Map<GameViewModel?>(await _mediator.Send(cmd));
    }
    public async Task<GameViewModel?> GameCreateNewAsync(GameCreateNewRequest request)
    {
        var cmd = _mapper.Map<GameCreateNewCmd>(request);
        return _mapper.Map<GameViewModel?>(await _mediator.Send(cmd));
    }
    public async Task<GameViewModel?> GameGetByIdAsync(GameGetByIdRequest request)
    {
        var qry = _mapper.Map<GameGetByIdQry>(request);
        return _mapper.Map<GameViewModel?>(await _mediator.Send(qry));
    }
    public async Task<GameViewModel?> GameGetFullGridAsync(GameGetFullGridRequest request)
    {
        var qry = _mapper.Map<GameGetFullGridQry>(request);
        return _mapper.Map<GameViewModel?>(await _mediator.Send(qry));
    }

}
