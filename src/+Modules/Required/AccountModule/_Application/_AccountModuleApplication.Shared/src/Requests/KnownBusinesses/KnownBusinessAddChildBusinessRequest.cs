namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessAddChildBusinessRequest : IRoutable
{
    public static string Route = "/api/KnownBusiness";
    public Guid ExistingBusinessId { get; set; }
    public KnownBusiness ChildBusiness { get; set; }
    private KnownBusinessAddChildBusinessRequest()
    {}
    public KnownBusinessAddChildBusinessRequest(Guid existingBusinessId, KnownBusiness childBusiness)
    {
        ExistingBusinessId = Guard.Against.NullOrEmpty(existingBusinessId, nameof(existingBusinessId));
        ChildBusiness = Guard.Against.Null(childBusiness, nameof(childBusiness));
    }


    public string BuildRouteFrom() => KnownBusinessAddChildBusinessRequest.BuildRoute();
    public static string BuildRoute() => Route;

    
}

