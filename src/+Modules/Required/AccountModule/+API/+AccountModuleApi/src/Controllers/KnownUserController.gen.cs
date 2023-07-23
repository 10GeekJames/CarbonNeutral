// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownUserController : BaseController
{
    public KnownUserController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> CreateByUserId(KnownUserCreateByUserIdCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<KnownUserViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetByUserId(KnownUserGetByUserIdQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownUserViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetByUserIdWebsiteId(KnownUserGetByUserIdWebsiteIdQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownUserViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Get(KnownUserGetQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<KnownUserViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAccount(KnownUserUpdateAccountCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<KnownUserViewModel>(result);
        return Ok(response);
    }

}
