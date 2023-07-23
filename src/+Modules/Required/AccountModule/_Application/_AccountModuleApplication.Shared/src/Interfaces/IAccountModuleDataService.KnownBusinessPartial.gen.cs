// ag=yes
namespace AccountModuleApplication.Shared.Interfaces; 
public partial interface IAccountModuleDataService
{
    Task<KnownBusinessViewModel?> KnownBusinessAddChildBusinessAsync(KnownBusinessAddChildBusinessRequest request);
    Task<KnownBusinessViewModel?> KnownBusinessGetByIdAsync(KnownBusinessGetByIdRequest request);
    Task<List<KnownBusinessViewModel>?> KnownBusinessGetChildBusinessesAsync(KnownBusinessGetChildBusinessesRequest request);

}