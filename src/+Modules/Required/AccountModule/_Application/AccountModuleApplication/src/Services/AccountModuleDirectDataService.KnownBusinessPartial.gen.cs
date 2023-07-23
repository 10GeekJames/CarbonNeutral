// ag=yes
namespace AccountModuleApplication.Services; 
public partial class AccountModuleDirectDataService
{
    public async Task<KnownBusinessViewModel?> KnownBusinessAddChildBusinessAsync(KnownBusinessAddChildBusinessRequest request)
    {
        var cmd = _mapper.Map<KnownBusinessAddChildBusinessCmd>(request);
        return _mapper.Map<KnownBusinessViewModel?>(await _mediator.Send(cmd));
    }
    public async Task<KnownBusinessViewModel?> KnownBusinessGetByIdAsync(KnownBusinessGetByIdRequest request)
    {
        var qry = _mapper.Map<KnownBusinessGetByIdQry>(request);
        return _mapper.Map<KnownBusinessViewModel?>(await _mediator.Send(qry));
    }
    public async Task<List<KnownBusinessViewModel>?> KnownBusinessGetChildBusinessesAsync(KnownBusinessGetChildBusinessesRequest request)
    {
        var qry = _mapper.Map<KnownBusinessGetChildBusinessesQry>(request);
        return _mapper.Map<List<KnownBusinessViewModel>?>(await _mediator.Send(qry));
    }

}
