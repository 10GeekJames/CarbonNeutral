namespace WskApplication.Services;
public partial class WskDirectDataService 
{
    public async Task<List<GameViewModel>?> GamesGetAllAsync()
    {
        var qry = new GamesGetAllQry();
        return _mapper.Map<List<GameViewModel>>(await _mediator.Send(qry));
    }    
}
