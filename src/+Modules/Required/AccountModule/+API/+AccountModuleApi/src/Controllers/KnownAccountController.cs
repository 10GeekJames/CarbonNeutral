namespace AccountModuleApi;
public class KnownAccountController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public KnownAccountController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] KnownAccountAddRequest cmd)
    {
        var userId = this.User.FindFirstValue(ClaimTypes.Name);
        var result = await _mediator.Send(cmd);
        return Ok(_mapper.Map<KnownAccountViewModel>(result));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] KnownAccountGetByEmailQry qry)
    {
        var result = await _mediator.Send(qry);
        return Ok(_mapper.Map<KnownAccountViewModel>(result));
    }
    
    
}
