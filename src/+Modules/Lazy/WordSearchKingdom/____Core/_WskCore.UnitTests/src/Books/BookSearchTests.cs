namespace WskCore.UnitTests;

public class BookSearchTests : BaseBooksTest
{
    
    [Fact]
    public void CanSearchBooksByYearRange()
    {
        // Given I have books
        ICreateManyBooks(BookWskTestData.AllBooks);

        // Given I have a search by year range specification
        var startYear = 1900;
        var endYear = 2020;

        var searchByYearRangeSpec = new BooksFindByYearRangeSpec(startYear, endYear);

        // When I search for books in that range
        var booksInRange = searchByYearRangeSpec.Evaluate(_booksToTestWith);

        // Then I find books in that range
        booksInRange.Should().NotBeEmpty();
        booksInRange.Should().HaveCountGreaterThan(0);

    }

    [Fact]
    public void CanSearchBooksByAuthor()
    {
        // Given I have authors
        var authors = AuthorWskTestData.AllAuthors;

        // Given I have books
        var books = BookWskTestData.AllBooks;
        books.Should().NotBeEmpty();
        
        // Given we have an author search string
        var searchFor = "john";
        var booksFindByAuthor = new BooksFindByAuthorSpec(searchFor);

        // When I search for books in that range
        var booksInRange = booksFindByAuthor.Evaluate(books);

        // Then I find books in that range
        booksInRange.Should().NotBeEmpty();
        booksInRange.Should().HaveCountGreaterThan(0);
    }


    [Fact]
    public void CanRemoveDamagedBookCopies()
    {
        // Given I have a book with multiple copies
        var manyCopiesMax = BookWskTestData.BookManyCopies;
        manyCopiesMax.Should().NotBeNull();

        // And I select the first book copy
        var randomBookCopy = manyCopiesMax.BookCopies.FirstOrDefault();
        manyCopiesMax.BookCopies.Count().Should().BeGreaterThan(1);

        // And I store the number of copies plus one to offset the index
        var numberOfCopies = manyCopiesMax.BookCopies.Count();

        // When I remove the damaged copy
        manyCopiesMax.RemoveBookCopy(randomBookCopy!);

        // Then I should have the same number of copies of the book
        manyCopiesMax.BookCopies.Count().Should().Be(numberOfCopies - 1);

        // And the damaged copy should be removed
        var spec = new BookCopyGetAllSpec();
        var bookCopies = spec.Evaluate(new List<Book>() { manyCopiesMax })?.FirstOrDefault()?.BookCopies;
        bookCopies!.FirstOrDefault(rs=>rs.CopySequence == randomBookCopy!.CopySequence).Should().BeNull();
    }
}