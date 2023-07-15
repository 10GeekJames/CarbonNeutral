namespace WskCore.Entities;
public class AuthorAddedToBookDomainEvent : BaseDomainEvent
{
    public Book Book { get; set; }
    public Author Author { get; set; }
    public AuthorAddedToBookDomainEvent(Book book, Author author)
    {
        Book = Guard.Against.Null(book, "Book is required");
        Author = Guard.Against.Null(author, "Author is required");
    }
}