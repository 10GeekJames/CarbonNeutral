// ag=yes
namespace AccountModuleApplication.Shared.Interfaces; 
public partial interface IAccountModuleDataService
{
    Task<KnownAccountViewModel?> KnownAccountAddAsync(KnownAccountAddRequest request);
    Task<KnownAccountViewModel?> KnownAccountGetByEmailAsync(KnownAccountGetByEmailRequest request);
    Task<KnownAccountViewModel?> KnownAccountGetByNameAsync(KnownAccountGetByNameRequest request);

}