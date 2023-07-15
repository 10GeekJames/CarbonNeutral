// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class WebsitePageContentRequest
{
    public static string Route = "/api/WebsitePageContent";

    public string BuildRouteFrom()
    {
        return WebsitePageContentRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}