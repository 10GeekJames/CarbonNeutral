namespace WskCore.Entities;
public class AuthorsAddedToBookDomainEvent : BaseDomainEvent
{
    public Book Book { get; set; }
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    
    public AuthorsAddedToBookDomainEvent(Book book, IEnumerable<Author> authors)
    {
        Book = Guard.Against.Null(book, "Book is required");
        Authors = Guard.Against.Null(authors, "Author is required");
    }
}