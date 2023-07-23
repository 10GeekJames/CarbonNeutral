// ag=yes
namespace AccountModuleApplication.Services; 
public partial class AccountModuleDirectDataService
{
    public async Task<KnownAccountViewModel?> KnownAccountAddAsync(KnownAccountAddRequest request)
    {
        var cmd = _mapper.Map<KnownAccountAddCmd>(request);
        return _mapper.Map<KnownAccountViewModel?>(await _mediator.Send(cmd));
    }
    public async Task<KnownAccountViewModel?> KnownAccountGetByEmailAsync(KnownAccountGetByEmailRequest request)
    {
        var qry = _mapper.Map<KnownAccountGetByEmailQry>(request);
        return _mapper.Map<KnownAccountViewModel?>(await _mediator.Send(qry));
    }

}
