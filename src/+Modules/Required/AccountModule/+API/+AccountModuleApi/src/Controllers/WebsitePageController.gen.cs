// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class WebsitePageController : BaseController
{
    public WebsitePageController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> GetByUrl(WebsitePageGetByUrlQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownBusinessWebsiteViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Update(WebsitePageUpdateCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<KnownBusinessWebsiteViewModel>(result);
        return Ok(response);
    }

}
