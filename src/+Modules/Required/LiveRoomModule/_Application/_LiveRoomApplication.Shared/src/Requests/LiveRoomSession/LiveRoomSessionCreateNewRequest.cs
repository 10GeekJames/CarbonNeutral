namespace LiveRoomApplication.Shared.Requests;

public class LiveRoomSessionCreateNewRequest : IRoutable
{
    protected readonly static string Route = "liveRoomSession/createnew";
    public string Slug { get; set; }
    public string Title { get; set; }
    public Guid? KnownUserId { get; set; } = null;

    public LiveRoomSessionCreateNewRequest() { }
    public LiveRoomSessionCreateNewRequest(string slug, string title, Guid? knownUserId = null)
    {
        Slug = slug;
        Title = title;
        KnownUserId = knownUserId;
    }
    public string BuildRouteFrom() => LiveRoomSessionCreateNewRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
