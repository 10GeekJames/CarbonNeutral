namespace WskCore.Entities;
public class BooksGetAllSpec : Specification<Book>
{
    public BooksGetAllSpec()
    {
        Query
            .Include(b => b.Authors)
            .Include(b => b.BookCopies)
            .OrderBy(s => s.Title);
    }
}
