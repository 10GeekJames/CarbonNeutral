namespace AccountModuleApi;
public class KnownUserController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public KnownUserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet, Authorize]
    public async Task<IActionResult> Get()
    {
        // alternatively
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        Guid? userId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        KnownUser? knownUser = null;

        var referrer = "";
        referrer = Request?.GetTypedHeaders()?.Referer?.Host.ToString();
        //Console.WriteLine($"Current Host == {referrer}");

        var knownBusinessWebsiteGetByUrlQry = new KnownBusinessWebsiteGetByUrlQry(referrer);
        var knownBusinessWebsiteGetByUrlResult = await _mediator.Send(knownBusinessWebsiteGetByUrlQry);

        if (userId.HasValue && knownBusinessWebsiteGetByUrlResult != null)
        {
            var knownUserGetByUserIdWebsiteIdQry = new KnownUserGetByUserIdWebsiteIdQry(userId.Value, knownBusinessWebsiteGetByUrlResult.Id);
            knownUser = await _mediator.Send(knownUserGetByUserIdWebsiteIdQry);
            if (knownUser == null)
            {
                var newUserCmd = new KnownUserCreateByUserIdCmd(userId.Value, knownBusinessWebsiteGetByUrlResult.Id);
                knownUser = await _mediator.Send(newUserCmd);
            }
        }
        
        return Ok(_mapper.Map<KnownUserViewModel>(knownUser));
    }

    [HttpPost, Authorize, Route("[action]")]
    public async Task<IActionResult> UpdateAccount(KnownUserUpdateAccountRequest request)
    {
        // alternatively
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        Guid? userId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        KnownUser? result = null;

        if (userId.HasValue)
        {
            var qry = new KnownUserGetByUserIdQry(userId.Value);
            var rs = await _mediator.Send(qry);
            if (rs != null)
            {
                var updateCmd = new KnownUserUpdateAccountCmd(rs.UserId, request.Name, request.EmailAddress);
                result = await _mediator.Send(updateCmd);
            }
        }
        return Ok(_mapper.Map<KnownUserViewModel>(result));
    }
}

