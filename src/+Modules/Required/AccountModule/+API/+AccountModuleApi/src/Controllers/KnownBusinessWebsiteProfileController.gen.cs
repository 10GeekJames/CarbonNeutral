// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownBusinessWebsiteProfileController : BaseController
{
    public KnownBusinessWebsiteProfileController(IMediator mediator, IMapper mapper, IAccountModuleDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> Update(KnownBusinessWebsiteProfileUpdateRequest request)
    {
        var response = await _dataService.KnownBusinessWebsiteProfileUpdateAsync(request);
        return Ok(response);
    }

}
