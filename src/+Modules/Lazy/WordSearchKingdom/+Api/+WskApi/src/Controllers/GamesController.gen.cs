// ag=yes
namespace WskApi.Controllers; 
public partial class GamesController : BaseController
{
    public GamesController(IMediator mediator, IMapper mapper, IDojoSurveysDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> GetAll(GamesGetAllRequest request)
    {
        var response = await _dataService.GamesGetAllAsync(request);
        return Ok(response);
    }

}
