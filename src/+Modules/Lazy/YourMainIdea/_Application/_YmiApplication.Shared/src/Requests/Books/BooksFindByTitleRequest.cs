namespace YmiApplication.Shared.Requests;

public class BooksFindByTitleRequest : IRoutable
{
    protected readonly static string Route = "/books/findbytitle/?searchFor={searchFor}";

    [Required]
    public string SearchFor { get; set; }

    public BooksFindByTitleRequest(string searchFor)
    {
        SearchFor = searchFor;
    }

    public string BuildRouteFrom()
    {
        return BooksFindByTitleRequest.BuildRoute(SearchFor);
    }
    public static string BuildRoute(string searchFor) { return Route.Replace("{searchFor}", searchFor); }
}
