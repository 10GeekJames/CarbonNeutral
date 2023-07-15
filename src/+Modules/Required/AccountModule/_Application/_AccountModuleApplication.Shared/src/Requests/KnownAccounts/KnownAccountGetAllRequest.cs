namespace AccountModuleApplication.Shared.Requests;
public class KnownAccountGetAllRequest : IRoutable //List
{
    public static string Route = "/api/AccountModule";

    public KnownAccountGetAllRequest()
    {
    }

    public string BuildRouteFrom() => KnownAccountGetAllRequest.BuildRoute();
    
    public static string BuildRoute() => Route;
}
