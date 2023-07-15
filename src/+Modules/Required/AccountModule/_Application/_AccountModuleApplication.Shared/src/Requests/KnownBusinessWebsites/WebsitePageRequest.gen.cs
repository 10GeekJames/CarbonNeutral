// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class WebsitePageRequest
{
    public static string Route = "/api/WebsitePage";

    public string BuildRouteFrom()
    {
        return WebsitePageRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}