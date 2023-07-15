namespace AccountModuleApplication.Services;

public partial class AccountModuleDirectDataService
{
    public async Task<KnownAccountViewModel> KnownAccountByNameAsync(string name)
    {
        return _mapper.Map<KnownAccountViewModel>(await _mediator.Send(name));
    }
    public async Task<List<KnownAccountViewModel>> AccountModuleListAsync()
    {
        return null;
    }
    public async Task<KnownAccountViewModel> KnownAccountAddAsync(KnownAccountAddRequest request)
    {
        var cmd = new KnownAccountAddCmd(request.AliasName, request.EmailAddress);
        return _mapper.Map<KnownAccountViewModel>(await _mediator.Send(cmd));
    }
    public async Task<List<KnownAccountViewModel>> KnownAccountAllAsync()
    {
        var qry = new KnownAccountGetAllQry();
        var result = await _mediator.Send(qry);

        return _mapper.Map<List<KnownAccountViewModel>>(result ?? new ());
    }
}