namespace WskApplication.Shared.Requests;

public class GameGetFullGridRequest : IRoutable
{
    protected readonly static string Route = "game/getFullGrid";
    public Guid Id { get; set; }
    public Guid KnownUserId { get; set; }
    public Guid GameGridInstanceId { get; set; }
    public GameGetFullGridRequest() { }
    public GameGetFullGridRequest(Guid gameId, Guid gameGridInstanceId)
    {
        GameGridInstanceId = gameGridInstanceId;
        Id = gameId;
    }
    public string BuildRouteFrom() => GameGetFullGridRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
