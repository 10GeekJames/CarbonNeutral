// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownBusinessProfileRequest
{
    public static string Route = "/KnownBusinessProfile/";

    public string BuildRouteFrom()
    {
        return KnownBusinessProfileRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}