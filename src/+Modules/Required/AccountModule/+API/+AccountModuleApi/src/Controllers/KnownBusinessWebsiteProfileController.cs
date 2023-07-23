namespace AccountModuleApi;
public class KnownBusinessWebsiteProfileController : BaseController
{
    public KnownBusinessWebsiteProfileController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] KnownBusinessWebsiteProfileUpdateRequest request)
    {
        var cmd = new KnownBusinessWebsiteProfileUpdateCmd(_mapper.Map<KnownBusinessWebsiteProfile>(request.KnownBusinessWebsiteProfile));
        var result = await _mediator.Send(cmd);
        return Ok(_mapper.Map<KnownBusinessWebsiteProfileViewModel>(result));
    }
}
