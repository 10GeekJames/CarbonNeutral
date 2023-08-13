// ag=yes
namespace LiveRoomApi.Controllers; 
public partial class LiveRoomSessionController : BaseController
{
    public LiveRoomSessionController(IMediator mediator, IMapper mapper, ILiveRoomDataService dataService) : base(mediator, mapper, dataService) { }
    [HttpPost]
    public async Task<IActionResult> CheckWordCoords(LiveRoomSessionCheckWordCoordsRequest request)
    {
        var response = await _dataService.LiveRoomSessionCheckWordCoordsAsync(request);
        return Ok(response);
    }

}
