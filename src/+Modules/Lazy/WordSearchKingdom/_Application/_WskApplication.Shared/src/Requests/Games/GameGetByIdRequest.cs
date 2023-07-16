namespace WskApplication.Shared.Requests;

public class GameGetByIdRequest : IRoutable
{
    protected readonly static string Route = "games/getbyid?id={Guid:Id}";
    public Guid Id { get; set; }
    public GameGetByIdRequest() {}
    public GameGetByIdRequest(Guid id)
    {
        Id = id;
    }
    public string BuildRouteFrom() => GameGetByIdRequest.BuildRoute(Id);
    public static string BuildRoute(Guid id) => Route.Replace("{Guid:Id}", id.ToString());
}