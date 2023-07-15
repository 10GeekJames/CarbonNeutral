namespace WskCore.Entities;
public class BooksFindByAuthorSpec : Specification<Book>
{
    public BooksFindByAuthorSpec(string searchString)
    {
        Query
            .Where(s => s.Authors != null && s.Authors.Any(rs => rs != null && rs.ToString().ToLower().Contains(searchString.ToLower())));
    }
}
