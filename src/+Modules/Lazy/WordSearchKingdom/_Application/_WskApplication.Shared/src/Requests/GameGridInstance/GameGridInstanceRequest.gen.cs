// ag=yes
namespace WskApplication.Shared.Requests; 
public partial class GameGridInstanceRequest
{
    public static string Route = "/GameGridInstance/";

    public string BuildRouteFrom()
    {
        return GameGridInstanceRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}