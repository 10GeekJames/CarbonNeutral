namespace WskApplication.Shared.Requests;

public class GamesGetAllRequest : IRoutable //List //Get //[FromQuery]
{
    protected readonly static string Route = "games/getall";
    public Guid? KnownUserId { get; set; } = null;
    
    public string BuildRouteFrom() => GamesGetAllRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
