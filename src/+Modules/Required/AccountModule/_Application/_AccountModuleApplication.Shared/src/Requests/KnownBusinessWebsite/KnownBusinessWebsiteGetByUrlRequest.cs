namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessWebsiteGetByUrlRequest : IRoutable //Get
{
    public static string Route = "/KnownBusinessWebsite/GetByUrl?Url={string:url}";
    public string Url {get;set;}
    public KnownBusinessWebsiteGetByUrlRequest(string url) {
        Url = Guard.Against.NullOrEmpty(url);
    }
    public string BuildRouteFrom() => KnownBusinessWebsiteGetByUrlRequest.BuildRoute(Url);
    public static string BuildRoute(string url) => Route.Replace("{string:url}", url);
}