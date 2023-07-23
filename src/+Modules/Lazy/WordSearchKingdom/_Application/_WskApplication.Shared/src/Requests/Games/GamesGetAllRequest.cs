namespace WskApplication.Shared.Requests;

public class GamesGetAllRequest : IRoutable //List
{
    protected readonly static string Route = "games/getall";

    public string BuildRouteFrom() => GamesGetAllRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
