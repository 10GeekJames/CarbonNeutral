// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownUserController : BaseController
{
    public KnownUserController(IMediator mediator, IMapper mapper, IAccountModuleDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> CreateByUserId(KnownUserCreateByUserIdRequest request)
    {
        var response = await _dataService.KnownUserCreateByUserIdAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetByEmailAddress(KnownUserGetByEmailAddressRequest request)
    {
        var response = await _dataService.KnownUserGetByEmailAddressAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetByUserId(KnownUserGetByUserIdRequest request)
    {
        var response = await _dataService.KnownUserGetByUserIdAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetByUserIdWebsiteId(KnownUserGetByUserIdWebsiteIdRequest request)
    {
        var response = await _dataService.KnownUserGetByUserIdWebsiteIdAsync(request);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> Get(KnownUserGetRequest request)
    {
        var response = await _dataService.KnownUserGetAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAccount(KnownUserUpdateAccountRequest request)
    {
        var response = await _dataService.KnownUserUpdateAccountAsync(request);
        return Ok(response);
    }

}
