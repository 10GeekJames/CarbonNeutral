namespace AccountModuleApplication.Shared.Requests;
public class KnownAccountGetByEmailRequest : IRoutable //Get
{
    public static string Route = "/KnownAccount?ServerEmail={string:emailAddress}";

    [Required]
    public string EmailAddress { get; set; }

    public KnownAccountGetByEmailRequest() { }
    public KnownAccountGetByEmailRequest(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public string BuildRouteFrom() => KnownAccountGetByEmailRequest.BuildRoute(EmailAddress);
    
    public static string BuildRoute(string emailAddress) => Route.Replace("{string:emailAddress}", emailAddress);
}
