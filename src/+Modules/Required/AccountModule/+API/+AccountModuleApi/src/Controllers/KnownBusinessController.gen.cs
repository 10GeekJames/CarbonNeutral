// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownBusinessController : BaseController
{
    public KnownBusinessController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> AddChildBusiness(KnownBusinessAddChildBusinessCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<KnownBusinessViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetById(KnownBusinessGetByIdQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownBusinessViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetChildBusinesses(KnownBusinessGetChildBusinessesQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<List<KnownBusinessViewModel>>(result);
        return Ok(response);
    }

}
