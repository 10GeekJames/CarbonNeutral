namespace YmiInfrastructure.CommandQuery;

public class BooksFindQry : IRequest<List<Book>>
{
    public string TitleSearch { get; set; }
    public IEnumerable<string>? AuthorSearch { get; set; }
    public IEnumerable<string>? CategorySearch { get; set; }
    public IEnumerable<string>? ConditionSearch { get; set; }

    public BooksFindQry(string titleSearch, IEnumerable<string>? authorSearch = null, IEnumerable<string>? categorySearch=null, IEnumerable<string>? conditionSearch=null)
    {
        TitleSearch = titleSearch;
        AuthorSearch = authorSearch;
        CategorySearch = categorySearch;
        ConditionSearch = conditionSearch;
    }
}
