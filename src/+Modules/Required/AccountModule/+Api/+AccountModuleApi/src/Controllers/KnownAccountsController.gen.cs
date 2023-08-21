// ag=yes
namespace AccountModuleApi.Controllers; 
public partial class KnownAccountsController : BaseController
{
    public KnownAccountsController(IMediator mediator, IMapper mapper, IAccountModuleDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpGet]
    public async Task<IActionResult> GetAll(KnownAccountsGetAllRequest request)
    {
        var response = await _dataService.KnownAccountsGetAllAsync(request);
        return Ok(response);
    }

}
