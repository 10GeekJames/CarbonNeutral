namespace YmiApplication.Shared.Requests;

public class BooksGetAllRequest : IRoutable
{
    protected readonly static string Route = "books/getall";

    public string BuildRouteFrom()
    {
        return BooksGetAllRequest.BuildRoute();
    }
    public static string BuildRoute() { return Route; }
}
