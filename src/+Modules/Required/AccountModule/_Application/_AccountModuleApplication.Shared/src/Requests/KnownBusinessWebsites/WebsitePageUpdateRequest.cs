namespace AccountModuleApplication.Shared.Requests;
public class WebsitePageUpdateRequest : IRoutable
{
    public static string Route = "/api/WebsitePage";
    public WebsitePageViewModel WebsitePage { get; set; }


    private WebsitePageUpdateRequest() { }
    public WebsitePageUpdateRequest(WebsitePageViewModel websitePage)
    {
        WebsitePage = websitePage;
    }
    
    public string BuildRouteFrom() => WebsitePageUpdateRequest.BuildRoute();

    public static string BuildRoute() => Route;
}
