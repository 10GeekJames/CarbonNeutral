// ag=yes
namespace WskApplication.Shared.Requests; 
public partial class GameTagRequest
{
    public static string Route = "/api/GameTag";

    public string BuildRouteFrom()
    {
        return GameTagRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}