namespace AccountModuleApplication.Shared.Requests;
public class KnownUserGetByUserIdWebsiteIdRequest : IRoutable
{
    public static string Route = "/api/KnownUser";


    public Guid KnownUserId { get; set; }
    public Guid KnownBusinessWebsiteId { get; set; }

    private KnownUserGetByUserIdWebsiteIdRequest() { }
    public KnownUserGetByUserIdWebsiteIdRequest(Guid knownUserId, Guid knownBusinessWebsiteId)
    {
        KnownUserId = Guard.Against.NullOrEmpty(knownUserId);
        KnownBusinessWebsiteId = knownBusinessWebsiteId;
    }

    public string BuildRouteFrom() => KnownUserGetByUserIdWebsiteIdRequest.BuildRoute();
   
    public static string BuildRoute() => Route;
}
