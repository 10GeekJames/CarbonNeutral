namespace YmiInfrastructure.CommandQuery;

public class BooksFindByTitleQry : IRequest<List<Book>>
{
    protected readonly static string Route = "/books/findbytitle/?searchFor={searchFor}";

    [Required]
    public string SearchFor { get; set; }

    public BooksFindByTitleQry(string searchFor)
    {
        SearchFor = searchFor;
    }
}
