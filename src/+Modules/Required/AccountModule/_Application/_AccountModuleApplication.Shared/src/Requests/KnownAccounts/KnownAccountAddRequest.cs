namespace AccountModuleApplication.Shared.Requests;
public class KnownAccountAddRequest : IRoutable
{
    public static string Route = "/api/KnownAccount";

    public string EmailAddress { get; set; }
    public string AliasName { get; set; }

    public KnownAccountAddRequest() { }
    public KnownAccountAddRequest(string aliasName, string emailAddress)
    {
        AliasName = Guard.Against.NullOrEmpty(aliasName, nameof(aliasName));
        EmailAddress = Guard.Against.NullOrEmpty(emailAddress, nameof(emailAddress));
    }

    public string BuildRouteFrom() => KnownAccountAddRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
