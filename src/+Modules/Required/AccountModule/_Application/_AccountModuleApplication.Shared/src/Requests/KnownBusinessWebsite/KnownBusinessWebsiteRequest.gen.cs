// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownBusinessWebsiteRequest
{
    public static string Route = "/KnownBusinessWebsite/";

    public string BuildRouteFrom()
    {
        return KnownBusinessWebsiteRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}