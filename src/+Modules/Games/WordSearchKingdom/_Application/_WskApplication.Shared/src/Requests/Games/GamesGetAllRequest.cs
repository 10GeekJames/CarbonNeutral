namespace WskApplication.Shared.Requests;

public class GamesGetAllRequest : IRoutable
{
    protected readonly static string Route = "games/getall";

    public string BuildRouteFrom()
    {
        return GamesGetAllRequest.BuildRoute();
    }
    public static string BuildRoute() { return Route; }
}
