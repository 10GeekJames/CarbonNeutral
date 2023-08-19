namespace LiveRoomApplication.Shared.Requests;

public class LiveRoomSessionGetByIdRequest : IRoutable
{
    protected readonly static string Route = "liveRoomSession/getbyid?id={Guid:Id}";  //Get
    public Guid Id { get; set; }
    public LiveRoomSessionGetByIdRequest() {}
    public LiveRoomSessionGetByIdRequest(Guid id)
    {
        Id = id;
    }
    public string BuildRouteFrom() => LiveRoomSessionGetByIdRequest.BuildRoute(Id);
    public static string BuildRoute(Guid id) => Route.Replace("{Guid:Id}", id.ToString());
}
