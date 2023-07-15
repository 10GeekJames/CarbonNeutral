namespace AccountModuleApplication.Shared.Requests;
public class KnownUserCreateByUserIdRequest : IRoutable
{
    public static string Route = "/api/KnownUser";
    private KnownUserCreateByUserIdRequest()
    { }
    public KnownUserCreateByUserIdRequest(Guid knownUserId, Guid knownBusinessWebsiteId)
    {
        KnownUserId = Guard.Against.NullOrEmpty(knownUserId);
        KnownBusinessWebsiteId = knownBusinessWebsiteId;
    }

    public Guid KnownUserId { get; set; }
    public Guid KnownBusinessWebsiteId { get; set; }

    public string BuildRouteFrom() => KnownUserCreateByUserIdRequest.BuildRoute();
   
    public static string BuildRoute() => Route;
}
