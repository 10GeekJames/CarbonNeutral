namespace WskCore.UnitTests;
public abstract class BaseBooksTest
{
    protected IsbnVO? _bookIsbn;
    protected Book? _bookToTestWith;
    protected List<Book> _booksToTestWith = new();
    protected BookCopy? _bookCopyToTestWith;
    protected List<Author>? _bookAuthorsToTestWith;
    protected List<BookCategory>? _bookCategoriesToTestWith;

    protected void ICreateABook(Book book, string reasonMessage = "")
    {
        _bookToTestWith = new Book(
            book.Isbn,
            book.Authors!,
            book.BookCategories,
            book.BookCopies,
            book.Title,
            book.PublicationYear,
            book.PageCount);

        _bookToTestWith.Should().NotBeNull(reasonMessage);
        _bookToTestWith.Isbn.Should().Be(book.Isbn, reasonMessage);
        _bookToTestWith!.Authors!.Count().Should().Be(book.Authors!.Count(), reasonMessage);
        _bookToTestWith!.BookCategories!.Count().Should().Be(book.BookCategories!.Count(), reasonMessage);
        _bookToTestWith.BookCopies.Count().Should().Be(book.BookCopies.Count(), reasonMessage);
        _bookToTestWith.Title.Should().Be(book.Title, reasonMessage);
        _bookToTestWith.PublicationYear.Should().Be(book.PublicationYear, reasonMessage);
        _bookToTestWith.PageCount.Should().Be(book.PageCount, reasonMessage);
    }
    protected void ICreateManyBooks(IEnumerable<Book> books, string reasonMessage = "")
    {
        foreach (var book in books)
        {
            var newBook = new Book(
                book.Isbn,
                book.Authors!,
                book.BookCategories,
                book.BookCopies,
                book.Title,
                book.PublicationYear,
                book.PageCount);

            newBook.Should().NotBeNull(reasonMessage);
            newBook.Isbn.Should().Be(book.Isbn, reasonMessage);
            newBook.Authors!.Count().Should().Be(book.Authors!.Count(), reasonMessage);
            newBook.BookCategories!.Count().Should().Be(book.BookCategories!.Count(), reasonMessage);
            newBook.BookCopies.Count().Should().Be(book.BookCopies.Count(), reasonMessage);
            newBook.Title.Should().Be(book.Title, reasonMessage);
            newBook.PublicationYear.Should().Be(book.PublicationYear, reasonMessage);
            newBook.PageCount.Should().Be(book.PageCount, reasonMessage);
            _booksToTestWith.Add(newBook);
        }
        _booksToTestWith.Count().Should().Be(books.Count());
    }
    protected void IHaveABookCopyOfCondition(BookCondition condition)
    {
        _bookCopyToTestWith = _bookToTestWith!.BookCopies.FirstOrDefault(rs => rs.Condition == condition);
        _bookCopyToTestWith.Should().NotBeNull();
        _bookCopyToTestWith!.Condition.Should().Be(BookCondition.Good);

    }
    protected void IHaveBookCategories()
    {
        if (_bookToTestWith!.BookCategories!.Count() == 0)
        {
            _bookToTestWith.AddBookCategory(BookWskTestData.BookCategoryFiction);
            _bookToTestWith.AddBookCategory(BookWskTestData.BookCategoryFantasy);
        }
    }
}
