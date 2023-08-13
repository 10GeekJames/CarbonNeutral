namespace LiveRoomApi.Controllers; 
public partial class LiveRoomSessionsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]LiveRoomSessionsGetAllRequest request)
    {
        // alternatively
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        Guid? userId = new Guid(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        
        if (userId.HasValue)
        {
            request.KnownUserId = userId.Value;
            var response = await _dataService.LiveRoomSessionsGetAllAsync(request);
            return Ok(response);                            
        }        
        return Ok(null);
    }
}
