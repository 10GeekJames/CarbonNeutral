// ag=yes
namespace LiveRoomApplication.Shared.Requests; 
public partial class LiveRoomSessionTagRequest
{
    public static string Route = "/LiveRoomSessionTag/";

    public string BuildRouteFrom()
    {
        return LiveRoomSessionTagRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}