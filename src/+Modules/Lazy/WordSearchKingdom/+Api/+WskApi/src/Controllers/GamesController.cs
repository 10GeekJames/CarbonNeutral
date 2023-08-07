namespace WskApi.Controllers; 
public partial class GamesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GamesGetAllRequest request)
    {
        // alternatively
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        Guid? userId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        
        if (userId.HasValue)
        {
            request.KnownUserId = userId.Value;
            var response = await _dataService.GamesGetAllAsync(request);
            return Ok(response);                            
        }        
        return Ok(null);
    }
}
