namespace AccountModuleApplication.Shared.Requests;
public class KnownUserGetRequest : IRoutable //Get
{
    public static string Route = "/KnownUser/Get";

    public KnownUserGetRequest() { }
    public string BuildRouteFrom() => KnownUserGetRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
