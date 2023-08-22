namespace WskApi.Controllers;
public partial class GameController : BaseController
{
    [HttpPost, Authorize]
    public async Task<IActionResult> CreateNew(GameCreateNewRequest request)
    {
        Guid userId = new Guid("00000000-0000-0000-0000-000000000001");
        var deserializedTags = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(request.GameTags);
        if (!deserializedTags.Contains("public", StringComparer.OrdinalIgnoreCase))
        {
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
        }

        try
        {
            var response = await _dataService.GameCreateNewAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return BadRequest("User not found");
    }

    [HttpPost]
    public async Task<IActionResult> GetById(GameGetByIdRequest request)
    {
        request.KnownUserId = new Guid("00000000-0000-0000-0000-000000000001");
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
        var response = await _dataService.GameGetByIdAsync(request);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetFullGrid(GameGetFullGridRequest request)
    {
        // alternatively
        request.KnownUserId = new Guid("00000000-0000-0000-0000-000000000001");
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
        var response = await _dataService.GameGetFullGridAsync(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CheckWordCoords(GameCheckWordCoordsRequest request)
    {
        request.KnownUserId = new Guid("00000000-0000-0000-0000-000000000001");
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

        var response = await _dataService.GameCheckWordCoordsAsync(request);
        return Ok(response);
    }

}
