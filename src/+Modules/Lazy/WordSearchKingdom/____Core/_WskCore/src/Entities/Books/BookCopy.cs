namespace WskCore.Entities;
public class BookCopy : BaseEntityTracked<Guid>
{
    public Guid BookId { get; init; }
    public Book Book { get; init; }

    public int CopySequence { get; private set; }
    public BookCondition Condition { get; private set; } = BookCondition.New;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private BookCopy() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public BookCopy(Book book, BookCondition bookCondition) : this(null, book, bookCondition) { }
    public BookCopy(Guid bookId, BookCondition bookCondition) : this(bookId, null, bookCondition) { }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private BookCopy(Guid? BookId, Book? book, BookCondition condition = BookCondition.New)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        if(BookId.HasValue) {
            BookId = BookId.Value;
        }

        if(book is not null) {
            Book = book;
        }
        if (!BookId.HasValue && book is null) {
            throw new ArgumentException("BookId or Book must be set");
        }

        Condition = condition;
        CopySequence = book!.BookCopies.Count() + 1;
    }
    
    public void ChangeCondition(BookCondition condition)
    {
        Condition = condition;
    }
}
