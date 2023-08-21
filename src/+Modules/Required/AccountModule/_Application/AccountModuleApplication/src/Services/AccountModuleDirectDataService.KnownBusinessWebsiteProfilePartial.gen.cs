// ag=yes
namespace AccountModuleApplication.Services; 
public partial class AccountModuleDirectDataService
{
    public async Task<KnownBusinessWebsiteProfileViewModel?> KnownBusinessWebsiteProfileUpdateAsync(KnownBusinessWebsiteProfileUpdateRequest request)
    {
        var cmd = _mapper.Map<KnownBusinessWebsiteProfileUpdateCmd>(request);
        return _mapper.Map<KnownBusinessWebsiteProfileViewModel?>(await _mediator.Send(cmd));
    }

}
