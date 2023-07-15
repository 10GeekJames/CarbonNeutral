namespace AccountModuleApplication.Services;

public partial class AccountModuleDirectDataService
{
    
    public async Task<KnownBusinessWebsiteViewModel> KnownBusinessWebsiteGetAsync(){
        /* var qry = new KnownBusinessWebsiteGetQry();
        return _mapper.Map<KnownAccountViewModel>(await _mediator.Send(qry)); */
        return null;
    }
    public async Task<WebsitePageViewModel> WebsitePageGetByUrlAsync(WebsitePageGetByUrlRequest request){
        return null;
    }
    public async Task<WebsitePageViewModel> WebsitePageUpdateAsync(WebsitePageUpdateRequest request){
        return null;
    }
    public async Task KnownBusinessWebsiteProfileUpdateAsync(KnownBusinessWebsiteProfileUpdateRequest request){
        
    }
    public async Task KnownBusinessWebsiteUpdateAsync(KnownBusinessWebsiteUpdateRequest request){
        
    }
}