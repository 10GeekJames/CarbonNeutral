// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownBusinessWebsiteProfileRequest
{
    public static string Route = "/KnownBusinessWebsiteProfile/";

    public string BuildRouteFrom()
    {
        return KnownBusinessWebsiteProfileRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}