// ag=yes
namespace LiveRoomApplication.Shared.Requests; 
public partial class LiveRoomSessionRequest
{
    public static string Route = "/LiveRoomSession/";

    public string BuildRouteFrom()
    {
        return LiveRoomSessionRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}