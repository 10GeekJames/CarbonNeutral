namespace YmiInfrastructure.CommandQuery;
public class BookAddCmdHandler : IRequestHandler<BookAddCmd, Book>
{
    private readonly IRepository<Book> _repository;
    public BookAddCmdHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }
    public async Task<Book> Handle(BookAddCmd request, CancellationToken cancellationToken)
    {
        var book = new Book(new(request.Isbn), request.Authors, null, request.BookCopies, request.Title, request.PublicationYear, request.PageCount);
        return await _repository.AddAsync(book, cancellationToken);
    }
}
