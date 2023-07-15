// ag=yes
namespace AccountModuleApplication.Shared.Requests; 
public partial class KnownAccountSubscriptionRequest
{
    public static string Route = "/api/KnownAccountSubscription";

    public string BuildRouteFrom()
    {
        return KnownAccountSubscriptionRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}