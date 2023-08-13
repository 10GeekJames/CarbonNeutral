// ag=yes
namespace LiveRoomApplication.Shared.Requests; 
public partial class LiveRoomSessionCategoryRequest
{
    public static string Route = "/LiveRoomSessionCategory/";

    public string BuildRouteFrom()
    {
        return LiveRoomSessionCategoryRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}