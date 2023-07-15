namespace YmiInfrastructure.CommandQuery;

public class BooksFindQryHandler : IRequestHandler<BooksFindQry, List<Book>>
{
    private readonly IRepository<Book> _repository;
    public BooksFindQryHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }
    public async Task<List<Book>> Handle(BooksFindQry qry, CancellationToken cancellationToken)
    {
        var booksFindSpec = new BooksFindSpec(qry.TitleSearch, qry.AuthorSearch, qry.CategorySearch, qry.ConditionSearch);
        return await _repository.ListAsync(booksFindSpec, cancellationToken);
    }
}