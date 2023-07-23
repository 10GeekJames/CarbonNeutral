namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessWebsiteGetRequest : IRoutable
{
    public static string Route = "/KnownBusinessWebsite/Get";
    public KnownBusinessWebsiteGetRequest() { }
    public string BuildRouteFrom() => KnownBusinessWebsiteGetRequest.BuildRoute();
   
    public static string BuildRoute() => Route;

}