// ag=yes
namespace WskApi.Controllers; 
public partial class GameController : BaseController
{
    public GameController(IMediator mediator, IMapper mapper, IWskDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> CheckWordCoords(GameCheckWordCoordsRequest request)
    {
        var response = await _dataService.GameCheckWordCoordsAsync(request);
        return Ok(response);
    }

}
