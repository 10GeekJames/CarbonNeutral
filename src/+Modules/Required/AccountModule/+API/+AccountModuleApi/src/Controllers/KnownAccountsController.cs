namespace AccountModuleApi;
public class AccountModuleController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AccountModuleController(IMediator mediator, IMapper mapper)
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
    public async Task<IActionResult> GetByAll()
    {
        var qry = new KnownAccountGetAllQry();
        var result = await _mediator.Send(qry);
        return Ok(_mapper.Map<List<KnownAccountViewModel>>(result));
    }

}
