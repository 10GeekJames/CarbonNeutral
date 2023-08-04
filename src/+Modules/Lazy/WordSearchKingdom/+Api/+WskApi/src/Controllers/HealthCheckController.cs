// ag=yes
namespace WskApi.Controllers; 
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("I am healthy!");
    }

}
