// ag=yes
namespace AccountModuleApplication.Services; 
public partial class AccountModuleDirectDataService
{
    public async Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteGetByUrlAsync(KnownBusinessWebsiteGetByUrlRequest request)
    {
        var qry = _mapper.Map<KnownBusinessWebsiteGetByUrlQry>(request);
        return _mapper.Map<KnownBusinessWebsiteViewModel?>(await _mediator.Send(qry));
    }
    public async Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteGetAsync(KnownBusinessWebsiteGetRequest request)
    {
        var qry = _mapper.Map<KnownBusinessWebsiteGetQry>(request);
        return _mapper.Map<KnownBusinessWebsiteViewModel?>(await _mediator.Send(qry));
    }
    public async Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteUpdateAsync(KnownBusinessWebsiteUpdateRequest request)
    {
        var cmd = _mapper.Map<KnownBusinessWebsiteUpdateCmd>(request);
        return _mapper.Map<KnownBusinessWebsiteViewModel?>(await _mediator.Send(cmd));
    }

}
