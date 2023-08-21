namespace LiveRoomApplication.Shared.Requests;

public class LiveRoomSessionsGetAllRequest : IRoutable //List //Get //[FromQuery]
{
    protected readonly static string Route = "liveRoomSessions/getall";
    public Guid KnownUserId { get; set; }

    public string BuildRouteFrom() => LiveRoomSessionsGetAllRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
