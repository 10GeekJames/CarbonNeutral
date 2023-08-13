// ag=yes
namespace LiveRoomApplication.Shared.Requests; 
public partial class LiveRoomSessionGridRequest
{
    public static string Route = "/LiveRoomSessionGrid/";

    public string BuildRouteFrom()
    {
        return LiveRoomSessionGridRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}