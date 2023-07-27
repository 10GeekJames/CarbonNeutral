// ag=yes
namespace AccountModuleApplication.Shared.Interfaces; 
public partial interface IAccountModuleDataService
{
    Task<List<KnownAccountViewModel>?> KnownAccountsGetAllAsync(KnownAccountsGetAllRequest request);

}