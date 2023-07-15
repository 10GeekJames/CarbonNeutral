namespace WskCore.Entities;
public class BookCheckedInDomainEvent : BaseDomainEvent
{
    public Library Library { get; set; }
    public Book Book { get; set; }
    public BookCheckedInDomainEvent(Library library, Book book)
    {
        Library = Guard.Against.Null(library, "Library is required");
        Book = Guard.Against.Null(book, "Book is required");
    }
}