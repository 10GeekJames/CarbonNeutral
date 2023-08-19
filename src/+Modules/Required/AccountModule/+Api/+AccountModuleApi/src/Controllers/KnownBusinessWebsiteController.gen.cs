// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownBusinessWebsiteController : BaseController
{
    public KnownBusinessWebsiteController(IMediator mediator, IMapper mapper, IAccountModuleDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpGet]
    public async Task<IActionResult> GetByUrl(KnownBusinessWebsiteGetByUrlRequest request)
    {
        var response = await _dataService.KnownBusinessWebsiteGetByUrlAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Get(KnownBusinessWebsiteGetRequest request)
    {
        var response = await _dataService.KnownBusinessWebsiteGetAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Update(KnownBusinessWebsiteUpdateRequest request)
    {
        var response = await _dataService.KnownBusinessWebsiteUpdateAsync(request);
        return Ok(response);
    }

}
