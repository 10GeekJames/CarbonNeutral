namespace AccountModuleApi;
public class KnownBusinessController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public KnownBusinessController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var referrer = Request?.GetTypedHeaders()?.Referer?.Host;
        var qry = new KnownBusinessWebsiteGetByUrlQry(referrer!);
        var result = await _mediator.Send(qry);
        return Ok(_mapper.Map<KnownBusinessViewModel>(result));
    }

    [HttpGet, Route("KnownBusinessGetChildBusinesses")]
    public async Task<IActionResult> KnownBusinessGetChildBusinesses()
    {
        var referrer = Request?.GetTypedHeaders()?.Referer?.Host;
        var parentBusinessQry = new KnownBusinessWebsiteGetByUrlQry(referrer!);
        var parentBusiness = await _mediator.Send(parentBusinessQry);

        KnownBusinessGetChildBusinessesQry qry = new(parentBusiness.Id);
        var result = await _mediator.Send(qry);
        return Ok(_mapper.Map<List<KnownBusinessViewModel>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] KnownBusinessAddChildBusinessCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        return Ok(_mapper.Map<KnownAccountViewModel>(result));
    }
}
