// ag=yes
namespace WskApplication.Shared.Requests; 
public partial class RowCellRequest
{
    public static string Route = "/api/RowCell";

    public string BuildRouteFrom()
    {
        return RowCellRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}