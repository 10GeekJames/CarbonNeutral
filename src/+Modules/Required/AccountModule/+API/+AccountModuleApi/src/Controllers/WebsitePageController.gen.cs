// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class WebsitePageController : BaseController
{
    public WebsitePageController(IMediator mediator, IMapper mapper, IDojoSurveysDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpGet]
    public async Task<IActionResult> GetByUrl(WebsitePageGetByUrlRequest request)
    {
        var response = await _dataService.WebsitePageGetByUrlAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Update(WebsitePageUpdateRequest request)
    {
        var response = await _dataService.WebsitePageUpdateAsync(request);
        return Ok(response);
    }

}
