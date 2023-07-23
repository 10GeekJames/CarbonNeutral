// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownAccountController : BaseController
{
    public KnownAccountController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> Add(KnownAccountAddCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<KnownAccountViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetByEmail(KnownAccountGetByEmailQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownAccountViewModel>(result);
        return Ok(response);
    }

}
