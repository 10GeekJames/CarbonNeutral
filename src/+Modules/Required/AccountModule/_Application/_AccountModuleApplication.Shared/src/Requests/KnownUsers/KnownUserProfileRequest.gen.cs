// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownUserProfileRequest
{
    public static string Route = "/api/KnownUserProfile";

    public string BuildRouteFrom()
    {
        return KnownUserProfileRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}