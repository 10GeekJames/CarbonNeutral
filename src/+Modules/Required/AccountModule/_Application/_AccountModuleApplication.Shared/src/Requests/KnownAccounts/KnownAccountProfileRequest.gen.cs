// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownAccountProfileRequest
{
    public static string Route = "/api/KnownAccountProfile";

    public string BuildRouteFrom()
    {
        return KnownAccountProfileRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}