// ag=yes
namespace WskApi.Controllers; 
public partial class GamesController : BaseController
{
    public GamesController(IMediator mediator, IMapper mapper, IWskDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GamesGetAllRequest request)
    {
        var response = await _dataService.GamesGetAllAsync(request);
        return Ok(response);
    }

}
