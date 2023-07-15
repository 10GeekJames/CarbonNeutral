namespace AccountModuleApplication.Shared.Requests;
public class KnownUserGetRequest : IRoutable
{
    public static string Route = "/api/KnownUser";

    public KnownUserGetRequest() { }
    public string BuildRouteFrom() => KnownUserGetRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
