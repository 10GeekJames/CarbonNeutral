namespace AccountModuleApplication.Shared.Requests;
public class KnownAccountGetByNameRequest : IRoutable //Get
{
    public static string Route = "/KnownAccount?AccountName={string:name}";

    [Required]
    public string Name { get; set; }

    private KnownAccountGetByNameRequest() { }
    public KnownAccountGetByNameRequest(string name)
    {
        Name = name;
    }

    public string BuildRouteFrom() => KnownAccountGetByNameRequest.BuildRoute(Name);
    public static string BuildRoute(string name) => Route.Replace("{string:name}", name);
}
