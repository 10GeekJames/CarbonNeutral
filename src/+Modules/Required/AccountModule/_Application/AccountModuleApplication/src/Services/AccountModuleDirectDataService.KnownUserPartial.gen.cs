// ag=yes
namespace AccountModuleApplication.Services; 
public partial class AccountModuleDirectDataService
{
    public async Task<KnownUserViewModel?> KnownUserCreateByUserIdAsync(KnownUserCreateByUserIdRequest request)
    {
        var cmd = _mapper.Map<KnownUserCreateByUserIdCmd>(request);
        return _mapper.Map<KnownUserViewModel?>(await _mediator.Send(cmd));
    }
    public async Task<KnownUserViewModel?> KnownUserGetByUserIdAsync(KnownUserGetByUserIdRequest request)
    {
        var qry = _mapper.Map<KnownUserGetByUserIdQry>(request);
        return _mapper.Map<KnownUserViewModel?>(await _mediator.Send(qry));
    }
    public async Task<KnownUserViewModel?> KnownUserGetByUserIdWebsiteIdAsync(KnownUserGetByUserIdWebsiteIdRequest request)
    {
        var qry = _mapper.Map<KnownUserGetByUserIdWebsiteIdQry>(request);
        return _mapper.Map<KnownUserViewModel?>(await _mediator.Send(qry));
    }
    public async Task<KnownUserViewModel?> KnownUserGetAsync(KnownUserGetRequest request)
    {
        var qry = _mapper.Map<KnownUserGetQry>(request);
        return _mapper.Map<KnownUserViewModel?>(await _mediator.Send(qry));
    }
    public async Task<KnownUserViewModel?> KnownUserUpdateAccountAsync(KnownUserUpdateAccountRequest request)
    {
        var cmd = _mapper.Map<KnownUserUpdateAccountCmd>(request);
        return _mapper.Map<KnownUserViewModel?>(await _mediator.Send(cmd));
    }

}
