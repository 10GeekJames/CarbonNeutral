namespace AccountModuleApplication.Shared.Requests;
public class KnownBusinessGetByIdRequest : IRoutable //Get
{
    public static string Route = "/KnownBusinessGetById?Url={guid:id}";

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
