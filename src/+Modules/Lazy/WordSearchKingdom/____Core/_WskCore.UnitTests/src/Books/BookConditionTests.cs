namespace WskCore.UnitTests;

public class BookConditionTests : BaseBooksTest
{
    [Fact]
    public void CanChangeBookCondition()
    {
        // Given I have books with copies
        ICreateABook(BookWskTestData.BookManyCopies);

        // Given I have a book copy that is in good condition
        IHaveABookCopyOfCondition(BookCondition.Good);

        // When I change the condition to poor
        _bookCopyToTestWith!.ChangeCondition(BookCondition.Poor);
        
        // Then the book is now in poor condition
        _bookCopyToTestWith.Condition.Should().Be(BookCondition.Poor);
    }

    [Fact]
    public void RemoveBookChangesConditionToDestroyed()
    {
        // Given I have a book with multiple copies
        ICreateABook(BookWskTestData.BookManyCopies);

        // And I select the first book copy
        IHaveABookCopyOfCondition(BookCondition.Good);

        // And I store the number of copies not destroyed
        var numberOfCopiesNotDestroyed = _bookToTestWith!.BookCopies.Count(rs=>rs.Condition != BookCondition.Destroyed);

        // When I remove the damaged copy
        _bookToTestWith.RemoveBookCopy(_bookCopyToTestWith!);

        // Then I should have one fewer copies of the book
        var numberOfCopiesNotDestroyedUpdated = _bookToTestWith.BookCopies.Count(rs=>rs.Condition != BookCondition.Destroyed);
        numberOfCopiesNotDestroyedUpdated.Should().Be(numberOfCopiesNotDestroyed - 1);
    }

    
}