namespace AccountModuleApplication.Shared.Interfaces;

public partial interface IAccountModuleDataService
{
    
    Task<KnownBusinessWebsiteViewModel> KnownBusinessWebsiteGetAsync();
    Task<WebsitePageViewModel> WebsitePageGetByUrlAsync(WebsitePageGetByUrlRequest request);
    Task<WebsitePageViewModel> WebsitePageUpdateAsync(WebsitePageUpdateRequest request);

    Task KnownBusinessWebsiteProfileUpdateAsync(KnownBusinessWebsiteProfileUpdateRequest request);
    Task KnownBusinessWebsiteUpdateAsync(KnownBusinessWebsiteUpdateRequest request);
}