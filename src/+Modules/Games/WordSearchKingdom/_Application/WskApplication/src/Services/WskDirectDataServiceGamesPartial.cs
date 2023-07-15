namespace WskApplication.Services;
public partial class WskDirectDataService 
{
    public async Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllQry qry)
    {
        return _mapper.Map<List<GameViewModel>>(await _mediator.Send(qry));
    }    
}
