// ag=yes
namespace WskApplication.Shared.Requests; 
public partial class GameCategoryRequest
{
    public static string Route = "/api/GameCategory";

    public string BuildRouteFrom()
    {
        return GameCategoryRequest.BuildRoute();
    }
    public static string BuildRoute() => Route;
}