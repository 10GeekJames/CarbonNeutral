namespace WskCore.Entities;
public class BooksFindByCategorySpec : Specification<Book>
{
    public BooksFindByCategorySpec(string searchString)
    {
        Query
            .Where(s => s.BookCategories != null && s.BookCategories.Any(rs => rs.Title.Contains(searchString)))
            .OrderBy(rs =>rs.BookCategories != null ? rs.BookCategories.Select(s => s.Title).ToString() : "Id");
    }
}
