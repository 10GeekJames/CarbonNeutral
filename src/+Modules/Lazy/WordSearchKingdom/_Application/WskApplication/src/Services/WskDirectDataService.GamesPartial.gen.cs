// ag=yes
namespace WskApplication.Services; 
public partial class WskDirectDataService
{
    public async Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllRequest request)
    {
        var qry = _mapper.Map<GamesGetAllQry>(request);
        return _mapper.Map<List<GameViewModel>?>(await _mediator.Send(qry));
    }

}
