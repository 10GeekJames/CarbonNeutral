namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessWebsiteUpdateRequest : IRoutable
{
    public static string Route = "/api/KnownBusinessWebsite";
    public KnownBusinessWebsiteViewModel KnownBusinessWebsite { get; set; }
    private KnownBusinessWebsiteUpdateRequest() { }
    public KnownBusinessWebsiteUpdateRequest(KnownBusinessWebsiteViewModel website)
    {
        KnownBusinessWebsite = website;
    }
    
    public string BuildRouteFrom() => KnownBusinessWebsiteUpdateRequest.BuildRoute();

    public static string BuildRoute() => Route;
}
