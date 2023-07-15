namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessWebsiteProfileUpdateRequest : IRoutable
{
    public static string Route = "/api/KnownBusinessWebsiteProfile";
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
