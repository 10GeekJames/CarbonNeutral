// ag=yes
namespace WskApplication.Shared.Requests; 
public partial class GameRequest
{
    public static string Route = "/Game/";

    public string BuildRouteFrom()
    {
        return GameRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}