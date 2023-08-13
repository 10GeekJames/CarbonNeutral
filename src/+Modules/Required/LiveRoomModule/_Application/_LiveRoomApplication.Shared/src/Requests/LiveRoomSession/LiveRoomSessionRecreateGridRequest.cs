namespace LiveRoomApplication.Shared.Requests;

public class LiveRoomSessionRecreateGridRequest : IRoutable
{
    protected readonly static string Route = "liveRoomSession/recreategrid";
    public Guid Id { get; set; }
    public LiveRoomSessionRecreateGridRequest() { }
    public LiveRoomSessionRecreateGridRequest(Guid id)
    {
        Id = id;
    }
    public string BuildRouteFrom() => LiveRoomSessionRecreateGridRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
