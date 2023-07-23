// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownBusinessController : BaseController
{
    public KnownBusinessController(IMediator mediator, IMapper mapper, IDojoSurveysDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> AddChildBusiness(KnownBusinessAddChildBusinessRequest request)
    {
        var response = await _dataService.KnownBusinessAddChildBusinessAsync(request);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetById(KnownBusinessGetByIdRequest request)
    {
        var response = await _dataService.KnownBusinessGetByIdAsync(request);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetChildBusinesses(KnownBusinessGetChildBusinessesRequest request)
    {
        var response = await _dataService.KnownBusinessGetChildBusinessesAsync(request);
        return Ok(response);
    }

}
