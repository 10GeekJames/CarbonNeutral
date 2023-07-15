namespace WskCore.Entities;

public class Book : BaseEntityTracked<Guid>, IAggregateRoot
{

    public IsbnVO Isbn { get; init; }
    public string Title { get; private set; }
    public int PublicationYear { get; private set; }
    public int PageCount { get; private set; }

    private readonly List<Author> _authors = new();
    public IEnumerable<Author>? Authors => _authors.AsReadOnly();

    private readonly List<BookCategory> _bookCategories = new();
    public IEnumerable<BookCategory>? BookCategories => _bookCategories.AsReadOnly();

    private List<BookCopy> _bookCopies = new();
    public IEnumerable<BookCopy> BookCopies => _bookCopies.Where(rs => rs.Condition != BookCondition.Destroyed).ToList().AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Book() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Book(IsbnVO isbn, IEnumerable<Author> authors, IEnumerable<BookCategory>? bookCategories, IEnumerable<BookCopy>? bookCopies, string title, int publicationYear, int pageCount)
    {
        Isbn = Guard.Against.Null(isbn, "because isbn is required");
        Title = Guard.Against.NullOrEmpty(title, "because title is required");
        PublicationYear = Guard.Against.Null(publicationYear, "because publicationYear is required");
        PageCount = Guard.Against.Null(pageCount, "because page count is required");

        Guard.Against.Null(authors, "because authors is required");
        
        _authors.AddRange(authors);
        if (bookCopies is not null)
        {
            _bookCopies.AddRange(bookCopies);
        }
        if (bookCategories is not null)
        {
            _bookCategories.AddRange(bookCategories);
        }
    }
    
    //Book/AddBookCopy(BookAddBookCopyRequest bookAddBookCopyRequest)[Result<Book>]
    public void AddBookCopy(BookCondition condition = BookCondition.New)
    {
        var bookCopy = new BookCopy(this, condition);
        _bookCopies.Add(bookCopy);
    }

    //Book/RemoveBookCopy(BookRemoveBookCopy bookRemoveBookCopy)[Result<Book>]
    public void RemoveBookCopy(BookCopy bookCopy)
    {
        bookCopy.ChangeCondition(BookCondition.Destroyed);
    }

    //Book/AddBookCategory(BookAddBookCategory bookAddBookCategory)[Result<Book>]
    public void AddBookCategory(BookCategory bookCategory)
    {
        if (!_bookCategories.Contains(bookCategory))
        {
            _bookCategories.Add(bookCategory);
        }
    }

    //Book/AddAuthor(BookAddBookAuthorRequest bookAddBookAuthorRequest)[Result<Book>]
    public void AddBookAuthor(Author author)
    {
        if (_authors.Any(x => x.Id == author.Id))
        {
            return;
        }
        _authors.Add(author);
    }

    //Book/RemoveBookAuthor(BookRemoveBookAuthorRequest bookRemoveBookAuthorRequest)[Result<Book>]
    public void RemoveBookAuthor(Author author)
    {
        if (_authors.Any(x => x.Id == author.Id))
        {
            _authors.Remove(author);
        }
    }
    
    //Book/RemoveBookCategory(BookRemoveBookCategoryRequest bookRemoveBookCategoryRequest)[Result<Book>]
    public void RemoveBookCategory(string categoryTitle)
    {
        var bookCategory = _bookCategories.FirstOrDefault(x => x.Title == categoryTitle);
        if (bookCategory != null)
        {
            _bookCategories.Remove(bookCategory);
        }
    }

    public override string ToString()
    {
        return $"{Title}| {Isbn}| {PublicationYear}| {PageCount}| {(Authors is null ? '|' : (String.Join(' ', Authors!.Select(x => x.ToString()))))}| {(BookCategories is null ? '|' : (String.Join(' ', BookCategories!.Select(x => x.ToString()))))}| ";
    }
}
