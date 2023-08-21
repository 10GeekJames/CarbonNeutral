// ag=yes
namespace AccountModuleApplication.Shared.Interfaces; 
public partial interface IAccountModuleDataService
{
    Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteGetByUrlAsync(KnownBusinessWebsiteGetByUrlRequest request);
    Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteGetAsync(KnownBusinessWebsiteGetRequest request);
    Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteUpdateAsync(KnownBusinessWebsiteUpdateRequest request);

}