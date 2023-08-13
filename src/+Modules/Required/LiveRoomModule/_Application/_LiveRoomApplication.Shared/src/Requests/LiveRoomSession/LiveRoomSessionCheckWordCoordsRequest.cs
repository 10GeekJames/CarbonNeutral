namespace LiveRoomApplication.Shared.Requests;

public class LiveRoomSessionCheckWordCoordsRequest : IRoutable
{
    protected readonly static string Route = "liveRoomSession/checkwordcoords";
    public Guid Id { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }



    public LiveRoomSessionCheckWordCoordsRequest() {}
    public LiveRoomSessionCheckWordCoordsRequest(Guid id, int x1, int y1, int x2, int y2)
    {
        Id = id;
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
    public string BuildRouteFrom() => LiveRoomSessionCheckWordCoordsRequest.BuildRoute();
    public static string BuildRoute() => Route;
}