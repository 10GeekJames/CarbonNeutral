// ag=yes
namespace WskApplication.Shared.Requests; 
public partial class GameGridRequest
{
    public static string Route = "/GameGrid/";

    public string BuildRouteFrom()
    {
        return GameGridRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}