// ag=yes
namespace LiveRoomApi.Controllers; 
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("I am healthy!");
    }

}
