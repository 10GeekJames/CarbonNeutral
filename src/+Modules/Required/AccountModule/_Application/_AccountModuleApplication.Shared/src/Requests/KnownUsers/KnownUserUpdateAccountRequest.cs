namespace AccountModuleApplication.Shared.Requests;
public class KnownUserUpdateAccountRequest : IRoutable
{
    public static string Route = "/api/KnownUser/UpdateAccount";

    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string EmailAddress { get; set; }

    private KnownUserUpdateAccountRequest()
    {

    }
    public KnownUserUpdateAccountRequest(string name, string emailAddress)
    {
        Name = Guard.Against.NullOrEmpty(name);
        EmailAddress = Guard.Against.NullOrEmpty(emailAddress);
    }
    public KnownUserUpdateAccountRequest(Guid userId, string name, string emailAddress) : this(name, emailAddress)
    {
        UserId = userId;
    }


    public string BuildRouteFrom() => KnownUserUpdateAccountRequest.BuildRoute();
   
    public static string BuildRoute() => Route;
}
