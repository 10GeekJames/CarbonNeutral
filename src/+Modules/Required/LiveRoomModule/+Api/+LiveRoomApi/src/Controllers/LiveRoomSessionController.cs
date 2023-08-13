namespace LiveRoomApi.Controllers;
public partial class LiveRoomSessionController : BaseController
{
    [HttpPost, Authorize]
    public async Task<IActionResult> CreateNew(LiveRoomSessionCreateNewRequest request)
    {
        // alternatively
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        Guid? userId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        if (userId.HasValue)
        {
            request.KnownUserId = userId.Value;
            var response = await _dataService.LiveRoomSessionCreateNewAsync(request);
            return Ok(response);
        }
        return Ok(null);

    }
    [HttpPost]
    public async Task<IActionResult> GetById(LiveRoomSessionGetByIdRequest request)
    {
        var response = await _dataService.LiveRoomSessionGetByIdAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> RecreateGrid(LiveRoomSessionRecreateGridRequest request)
    {
        var response = await _dataService.LiveRoomSessionRecreateGridAsync(request);
        return Ok(response);
    }
}
