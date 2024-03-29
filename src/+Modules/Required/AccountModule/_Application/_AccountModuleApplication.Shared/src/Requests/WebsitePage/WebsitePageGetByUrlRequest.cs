namespace AccountModuleApplication.Shared.Requests;
public class WebsitePageGetByUrlRequest : IRoutable //Get
{
    public static string Route = "/WebsitePage?Url={string:url}";

    [Required]
    public string Url { get; set; }

    private WebsitePageGetByUrlRequest() { }
    public WebsitePageGetByUrlRequest(string url)
    {
        Url = url;
    }

    public string BuildRouteFrom() => WebsitePageGetByUrlRequest.BuildRoute(Url);

    public static string BuildRoute(string url) => Route.Replace("{string:url}", url);
}
