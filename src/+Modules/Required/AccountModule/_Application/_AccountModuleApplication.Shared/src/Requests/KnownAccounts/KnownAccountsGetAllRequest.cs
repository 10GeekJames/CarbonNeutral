namespace AccountModuleApplication.Shared.Requests;
public class KnownAccountsGetAllRequest : IRoutable //Get //List
{
    public static string Route = "/KnownAccounts/GetAll";

    public KnownAccountsGetAllRequest()
    {
    }

    public string BuildRouteFrom() => KnownAccountsGetAllRequest.BuildRoute();
    
    public static string BuildRoute() => Route;
}
