namespace WskApi.Controllers;
public partial class GamesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GamesGetAllRequest request)
    {
        // alternatively
        Guid userId = new Guid("00000000-0000-0000-0000-000000000001");
        try
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            Guid? claimUserId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (claimUserId.HasValue)
            {
                request.KnownUserId = claimUserId.Value;
            }
        }
        catch (Exception) { }
        var response = await _dataService.GamesGetAllAsync(request);
        return Ok(response);
    }
}
