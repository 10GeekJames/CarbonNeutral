// ag=yes
namespace AccountModuleApplication.Shared.Interfaces; 
public partial interface IAccountModuleDataService
{
    Task<KnownBusinessWebsiteViewModel?> WebsitePageGetByUrlAsync(WebsitePageGetByUrlRequest request);
    Task<KnownBusinessWebsiteViewModel?> WebsitePageUpdateAsync(WebsitePageUpdateRequest request);

}