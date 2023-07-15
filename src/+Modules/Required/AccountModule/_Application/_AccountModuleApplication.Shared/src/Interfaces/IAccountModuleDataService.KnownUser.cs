namespace AccountModuleApplication.Shared.Interfaces;

public partial interface IAccountModuleDataService
{
    
    Task<KnownUserViewModel> KnownUserGetAsync();
    Task<KnownUserViewModel> KnownUserUpdateAccountAsync(KnownUserUpdateAccountRequest request);
}