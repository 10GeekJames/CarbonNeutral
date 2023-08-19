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
            try
            {
                var response = await _dataService.GameCreateNewAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        return BadRequest("User not found");
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
        // alternatively
        Guid? userId = null;
        try
        {

            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            userId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            request.KnownUserId = userId;
            var response = await _dataService.GameRecreateGridAsync(request);
            return Ok(response);
        }
        catch (Exception) { }
        
        var response = await _dataService.GameRecreateGridAsync(request);
        return Ok(response);
    }
}
