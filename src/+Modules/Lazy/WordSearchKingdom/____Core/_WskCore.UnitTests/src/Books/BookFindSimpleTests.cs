
namespace WskCore.UnitTests;

public class BookFindSimpleTests : BaseBooksTest
{
    [Fact]
    public void CanCreateBookWithCopies()
    {
        // When I create a book with many copies
        ICreateABook(BookWskTestData.BookManyCopies);

        // And test book has the correct book copies
        _bookToTestWith!.BookCopies.Count().Should().Be(BookWskTestData.BookManyCopies.BookCopies.Count());
    }

    [Fact]
    public void CanCreateBookWithCategories()
    {
        // When I set test data to a book with categories
        ICreateABook(BookWskTestData.BookWithCategories);

        // Then book has the correct book categories
        _bookToTestWith!.BookCategories!.Count().Should().Be(BookWskTestData.BookWithCategories.BookCategories!.Count());
    }
}