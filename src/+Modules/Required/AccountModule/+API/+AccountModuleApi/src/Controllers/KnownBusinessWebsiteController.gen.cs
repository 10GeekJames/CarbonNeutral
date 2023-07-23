// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownBusinessWebsiteController : BaseController
{
    public KnownBusinessWebsiteController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> GetByUrl(KnownBusinessWebsiteGetByUrlQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownBusinessWebsiteViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Get(KnownBusinessWebsiteGetQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownBusinessWebsiteViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Update(KnownBusinessWebsiteUpdateCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<KnownBusinessWebsiteViewModel>(result);
        return Ok(response);
    }

}
