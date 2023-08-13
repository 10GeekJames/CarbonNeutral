// ag=yes
namespace LiveRoomApplication.Shared.Requests; 
public partial class HiddenWordRequest
{
    public static string Route = "/HiddenWord/";

    public string BuildRouteFrom()
    {
        return HiddenWordRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}