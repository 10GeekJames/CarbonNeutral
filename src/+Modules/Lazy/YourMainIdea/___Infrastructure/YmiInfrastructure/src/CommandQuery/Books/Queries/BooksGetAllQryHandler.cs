namespace YmiInfrastructure.CommandQuery;

public class BooksGetAllQryHandler : IRequestHandler<BooksGetAllQry, List<Book>>
{
    private readonly IRepository<Book> _repository;
    public BooksGetAllQryHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }
    public async Task<List<Book>> Handle(BooksGetAllQry qry, CancellationToken cancellationToken)
    {
        var booksGetAllSpec = new BooksGetAllSpec();
        return await _repository.ListAsync(booksGetAllSpec, cancellationToken);
    }
}