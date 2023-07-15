namespace YmiApplication.Shared.Requests;

public class BooksFindRequest : IRoutable
{
    protected readonly static string Route = "/books/find?titleSearch{string:titleSearch}&{authorSearchParamArray}{categorySearchParamArray}{conditionSearchParamArray}";

    public string TitleSearch { get; set; }
    public IEnumerable<string> AuthorSearch { get; set; }
    public IEnumerable<string> CategorySearch { get; set; }
    public IEnumerable<string> ConditionSearch { get; set; }

    public BooksFindRequest(string titleSearch, IEnumerable<string> authorSearch, IEnumerable<string> categorySearch, IEnumerable<string> conditionSearch)
    {
        TitleSearch = titleSearch;
        AuthorSearch = authorSearch;
        CategorySearch = categorySearch;
        ConditionSearch = conditionSearch;
    }

    public string BuildRouteFrom()
    {
        return BuildRoute(TitleSearch, AuthorSearch, CategorySearch, ConditionSearch);
    }
    public static string BuildRoute(BooksFindQry qry) {
        return BuildRoute(qry.TitleSearch, qry.AuthorSearch, qry.CategorySearch, qry.ConditionSearch);
    }
    public static string BuildRoute(string titleSearch, IEnumerable<string> authorSearch, IEnumerable<string> categorySearch, IEnumerable<string> conditionSearch)
    {
        return Route.Replace("{titleSearch}", titleSearch)
            .Replace("{authorSearchParamArray}", authorSearch is not null ? $"&authorSearch={string.Join("&authorSearch=", authorSearch)}" : "")
            .Replace("{categorySearchParamArray}", categorySearch is not null ? $"&categorySearch={string.Join("&categorySearch=", categorySearch)}" : "")
            .Replace("{conditionSearchParamArray}", conditionSearch is not null ? $"&conditionSearch={string.Join("&conditionSearch=", conditionSearch)}" : "");
    }
}
