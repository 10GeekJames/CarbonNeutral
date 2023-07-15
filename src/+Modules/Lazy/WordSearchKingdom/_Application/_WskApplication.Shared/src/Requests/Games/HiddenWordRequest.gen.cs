// ag=yes
namespace WskApplication.Shared.Requests; 
public partial class HiddenWordRequest
{
    public static string Route = "/api/HiddenWord";

    public string BuildRouteFrom()
    {
        return HiddenWordRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}