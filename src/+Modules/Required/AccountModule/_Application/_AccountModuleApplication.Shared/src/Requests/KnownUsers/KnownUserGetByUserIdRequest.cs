namespace AccountModuleApplication.Shared.Requests;
public class KnownUserGetByUserIdRequest : IRoutable
{
    public static string Route = "/api/KnownUser";
    
    public Guid UserId { get; set; }

    private KnownUserGetByUserIdRequest()
    { 

    }
    public KnownUserGetByUserIdRequest(Guid userId)
    {
        UserId = Guard.Against.NullOrEmpty(userId);
    }    

    public string BuildRouteFrom() => KnownUserGetByUserIdRequest.BuildRoute();
   
    public static string BuildRoute() => Route;
}
