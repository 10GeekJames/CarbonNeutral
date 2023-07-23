// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownBusinessWebsiteAliasRequest
{
    public static string Route = "/KnownBusinessWebsiteAlias/";

    public string BuildRouteFrom()
    {
        return KnownBusinessWebsiteAliasRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}