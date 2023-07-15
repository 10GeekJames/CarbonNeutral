// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownAccountRequest
{
    public static string Route = "/api/KnownAccount";

    public string BuildRouteFrom()
    {
        return KnownAccountRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}