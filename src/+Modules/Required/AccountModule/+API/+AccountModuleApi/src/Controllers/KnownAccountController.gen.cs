// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownAccountController : BaseController
{
    public KnownAccountController(IMediator mediator, IMapper mapper, IDojoSurveysDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> Add(KnownAccountAddRequest request)
    {
        var response = await _dataService.KnownAccountAddAsync(request);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetByEmail(KnownAccountGetByEmailRequest request)
    {
        var response = await _dataService.KnownAccountGetByEmailAsync(request);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetByName(KnownAccountGetByNameRequest request)
    {
        var response = await _dataService.KnownAccountGetByNameAsync(request);
        return Ok(response);
    }

}
