// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class WebsitePageContentRequest
{
    public static string Route = "/WebsitePageContent/";

    public string BuildRouteFrom()
    {
        return WebsitePageContentRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}