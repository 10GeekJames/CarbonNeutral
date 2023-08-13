// ag=yes
namespace LiveRoomApplication.Shared.Requests; 
public partial class RowCellRequest
{
    public static string Route = "/RowCell/";

    public string BuildRouteFrom()
    {
        return RowCellRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}