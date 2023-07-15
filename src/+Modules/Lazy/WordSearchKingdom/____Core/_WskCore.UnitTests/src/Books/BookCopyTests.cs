namespace WskCore.UnitTests.Books
{
    public class BookCopyTests : BaseBooksTest
    {
        [Fact]
        public void LibraryCanHaveMultipleCopiesOfTheSameBook()
        {
            // Given I have a book with no copies
            ICreateABook(BookWskTestData.BookNoCopies);
            _bookToTestWith!.BookCopies.Should().BeEmpty();

            // When I add a book copy
            _bookToTestWith!.AddBookCopy(BookCondition.Good);

            // Then there should be on copy of the book
            _bookToTestWith!.BookCopies.Should().NotBeEmpty();
            _bookToTestWith!.BookCopies.Count().Should().Be(1);
        }
    }
}