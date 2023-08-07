namespace WskApi.Controllers;
public partial class GameController : BaseController
{
    [HttpPost, Authorize]
    public async Task<IActionResult> CreateNew(GameCreateNewRequest request)
    {
        // alternatively
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        Guid? userId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        if (userId.HasValue)
        {
            request.KnownUserId = userId.Value;
            var response = await _dataService.GameCreateNewAsync(request);
            return Ok(response);
        }
        return Ok(null);

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
