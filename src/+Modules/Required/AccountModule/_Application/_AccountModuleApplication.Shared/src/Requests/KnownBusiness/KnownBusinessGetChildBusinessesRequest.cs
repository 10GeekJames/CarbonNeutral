namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessGetChildBusinessesRequest : IRoutable //Get
{
    public static string Route = "/KnownBusinessGetById?Id={guid:id}";

    [Required]
    public Guid Id { get; set; }

    private KnownBusinessGetChildBusinessesRequest() { }
    public KnownBusinessGetChildBusinessesRequest(Guid id)
    {
        Id = id;
    }

    public string BuildRouteFrom() => KnownBusinessGetChildBusinessesRequest.BuildRoute(Id);

    public static string BuildRoute(Guid id) => Route.Replace("{guid:id}", id.ToString());
}
