namespace YmiInfrastructure.CommandQuery;

public class BooksFindByTitleQryHandler : IRequestHandler<BooksFindByTitleQry, List<Book>>
{
    private readonly IRepository<Book> _repository;
    public BooksFindByTitleQryHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }
    public async Task<List<Book>> Handle(BooksFindByTitleQry qry, CancellationToken cancellationToken)
    {
        var booksFindByTitleSpec = new BooksFindByTitleSpec(qry.SearchFor);
        return await _repository.ListAsync(booksFindByTitleSpec, cancellationToken);
    }
}