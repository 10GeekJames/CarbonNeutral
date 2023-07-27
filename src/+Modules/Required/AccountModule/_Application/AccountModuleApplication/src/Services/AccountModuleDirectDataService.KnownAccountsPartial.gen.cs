// ag=yes
namespace AccountModuleApplication.Services; 
public partial class AccountModuleDirectDataService
{
    public async Task<List<KnownAccountViewModel>?> KnownAccountsGetAllAsync(KnownAccountsGetAllRequest request)
    {
        var qry = _mapper.Map<KnownAccountsGetAllQry>(request);
        return _mapper.Map<List<KnownAccountViewModel>?>(await _mediator.Send(qry));
    }

}
