// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownBusinessWebsiteProfileController : BaseController
{
    public KnownBusinessWebsiteProfileController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> Update(KnownBusinessWebsiteProfileUpdateCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<KnownBusinessWebsiteProfileViewModel>(result);
        return Ok(response);
    }

}
