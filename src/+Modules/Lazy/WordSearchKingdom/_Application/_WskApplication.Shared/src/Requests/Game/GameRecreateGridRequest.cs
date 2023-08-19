namespace WskApplication.Shared.Requests;

public class GameRecreateGridRequest : IRoutable
{
    protected readonly static string Route = "game/recreategrid";
    public Guid Id { get; set; }
    public Guid? KnownUserId { get; set; } = null;
    public GameRecreateGridRequest() { }
    public GameRecreateGridRequest(Guid id)
    {
        Id = id;
    }
    public string BuildRouteFrom() => GameRecreateGridRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
