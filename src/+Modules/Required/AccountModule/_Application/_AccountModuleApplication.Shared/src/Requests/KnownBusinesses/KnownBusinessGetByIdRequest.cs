namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessGetByIdRequest : IRoutable
{
    public static string Route = "/api/KnownBusinessGetById?Url={guid:id}";

    [Required]
    public Guid Id { get; set; }

    private KnownBusinessGetByIdRequest() { }
    public KnownBusinessGetByIdRequest(Guid id)
    {
        Id = id;
    }

    public string BuildRouteFrom() => KnownBusinessGetByIdRequest.BuildRoute(Id);

    public static string BuildRoute(Guid id) => Route.Replace("{guid:id}", id.ToString());
}
