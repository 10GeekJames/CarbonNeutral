namespace AccountModuleApi;
public class KnownBusinessWebsiteController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public KnownBusinessWebsiteController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<KnownBusinessWebsiteViewModel> Get()
    {
        var referrer = "";
        referrer = Request?.GetTypedHeaders()?.Referer?.Host.ToString();
        //Console.WriteLine($"Current Host == {referrer}");

        var qry = new KnownBusinessWebsiteGetByUrlQry(referrer);
        var result = await _mediator.Send(qry);

        return _mapper.Map<KnownBusinessWebsiteViewModel>(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] KnownBusinessWebsiteUpdateCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        return Ok();
    }
}
