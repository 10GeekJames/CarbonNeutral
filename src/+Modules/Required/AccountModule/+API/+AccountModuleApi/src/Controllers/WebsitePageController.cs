namespace AccountModuleApi;
public class WebsitePageController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public WebsitePageController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet, Authorize] // lets go ahead and get Roles = "MSP" happy ;)
    public async Task<KnownBusinessWebsiteViewModel> Get([FromQuery] WebsitePageGetByUrlQry qry)
    {
        //var userId = this.User.FindFirstValue(ClaimTypes.Name);

        var result = await _mediator.Send(qry);

        return _mapper.Map<KnownBusinessWebsiteViewModel>(result);
    }

    [HttpPost]
    public async Task<WebsitePageViewModel> Post([FromBody] WebsitePageUpdateRequest request)
    {
        var cmd = new WebsitePageUpdateCmd(_mapper.Map<WebsitePage>(request.WebsitePage));
        var result = await _mediator.Send(cmd);
        
        return _mapper.Map<WebsitePageViewModel>(result.WebsitePages.FirstOrDefault());
    }
}
