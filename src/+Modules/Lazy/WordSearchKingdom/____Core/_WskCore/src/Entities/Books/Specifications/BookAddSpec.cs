namespace WskCore.Entities;
public class BookAddSpec : Specification<Book>
{
    public BookAddSpec()
    {
        Query
            .Include(b => b.Authors)
            .Include(b => b.BookCopies)
            .OrderBy(s => s.Title);
    }
}
