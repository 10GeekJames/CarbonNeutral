namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessWebsiteGetByUrlRequest : IRoutable
{
    public static string Route = "/api/KnownBusinessWebsite";
    public string Url {get;set;}
    public KnownBusinessWebsiteGetByUrlRequest(string url) {
        Url = Guard.Against.NullOrEmpty(url);
    }
    public string BuildRouteFrom() => KnownBusinessWebsiteGetByUrlRequest.BuildRoute();
    public static string BuildRoute() => Route;
}