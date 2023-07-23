namespace AccountModuleApplication.Shared.Requests;
public class KnownUserGetByEmailAddressRequest : IRoutable
{
    public static string Route = "/KnownUser/GetByEmailAddress";
    public string EmailAddress { get; set; }
    private KnownUserGetByEmailAddressRequest()
    { }
    public KnownUserGetByEmailAddressRequest(string emailAddress)
    {
        EmailAddress = Guard.Against.NullOrEmpty(emailAddress);
    }

    public string BuildRouteFrom() => KnownUserGetByEmailAddressRequest.BuildRoute();
   
    public static string BuildRoute() => Route;
}
