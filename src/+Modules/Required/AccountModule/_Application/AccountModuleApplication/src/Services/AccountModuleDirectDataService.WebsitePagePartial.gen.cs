// ag=yes
namespace AccountModuleApplication.Services; 
public partial class AccountModuleDirectDataService
{
    public async Task<KnownBusinessWebsiteViewModel?> WebsitePageGetByUrlAsync(WebsitePageGetByUrlRequest request)
    {
        var qry = _mapper.Map<WebsitePageGetByUrlQry>(request);
        return _mapper.Map<KnownBusinessWebsiteViewModel?>(await _mediator.Send(qry));
    }
    public async Task<KnownBusinessWebsiteViewModel?> WebsitePageUpdateAsync(WebsitePageUpdateRequest request)
    {
        var cmd = _mapper.Map<WebsitePageUpdateCmd>(request);
        return _mapper.Map<KnownBusinessWebsiteViewModel?>(await _mediator.Send(cmd));
    }

}
