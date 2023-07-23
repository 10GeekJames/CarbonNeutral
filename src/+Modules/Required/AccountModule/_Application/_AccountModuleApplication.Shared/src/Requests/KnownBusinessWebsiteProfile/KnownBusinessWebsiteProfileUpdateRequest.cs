namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessWebsiteProfileUpdateRequest : IRoutable
{
    public static string Route = "/KnownBusinessWebsiteProfile/Update";
    public KnownBusinessWebsiteProfileViewModel KnownBusinessWebsiteProfile { get; set; }

    private KnownBusinessWebsiteProfileUpdateRequest() 
    { }

    public KnownBusinessWebsiteProfileUpdateRequest(KnownBusinessWebsiteProfileViewModel knownBusinessWebsiteProfile)
    {
        KnownBusinessWebsiteProfile = knownBusinessWebsiteProfile;
    }

    public string BuildRouteFrom() => KnownBusinessWebsiteProfileUpdateRequest.BuildRoute();

    public static string BuildRoute() => Route;
}
