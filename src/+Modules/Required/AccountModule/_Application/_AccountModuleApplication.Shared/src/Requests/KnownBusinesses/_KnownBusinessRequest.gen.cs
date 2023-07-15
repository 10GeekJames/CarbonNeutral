// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownBusinessRequest
{
    public static string Route = "/api/KnownBusiness";

    public string BuildRouteFrom()
    {
        return KnownBusinessRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}