namespace AccountModuleApi;
public class KnownBusinessWebsiteProfileController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public KnownBusinessWebsiteProfileController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] KnownBusinessWebsiteProfileUpdateRequest request)
    {
        var cmd = new KnownBusinessWebsiteProfileUpdateCmd(_mapper.Map<KnownBusinessWebsiteProfile>(request.KnownBusinessWebsiteProfile));
        var result = await _mediator.Send(cmd);
        return Ok(_mapper.Map<KnownBusinessWebsiteProfileViewModel>(result));
    }
}
