namespace WskApplication.Shared.Requests;

public class GamesGetAllRequest : IRoutable //List //Get //[FromQuery]
{
    protected readonly static string Route = "games/getall?userOnly={bool:userOnly}";
    public Guid KnownUserId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public bool UserOnly { get; set; } = true;
    
    public string BuildRouteFrom() => GamesGetAllRequest.BuildRoute(UserOnly);
    public static string BuildRoute(bool userOnly) => Route.Replace("{bool:userOnly}", userOnly.ToString());
}
