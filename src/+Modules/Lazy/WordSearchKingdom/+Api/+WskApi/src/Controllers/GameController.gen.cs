// ag=yes
namespace WskApi.Controllers; 
public partial class GameController : BaseController
{
    public GameController(IMediator mediator, IMapper mapper, IDojoSurveysDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> CheckWordCoords(GameCheckWordCoordsRequest request)
    {
        var response = await _dataService.GameCheckWordCoordsAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> CreateNew(GameCreateNewRequest request)
    {
        var response = await _dataService.GameCreateNewAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetById(GameGetByIdRequest request)
    {
        var response = await _dataService.GameGetByIdAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> RecreateGrid(GameRecreateGridRequest request)
    {
        var response = await _dataService.GameRecreateGridAsync(request);
        return Ok(response);
    }

}
