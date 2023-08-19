namespace CarbonNeutral.Signal.Controllers;
public class HealthCheck : Controller
{
    [HttpGet]
    [Route("healthcheck")]
    public IActionResult Get()
    {
        return Ok("Healthy");
    }
}
