namespace WskCore.Entities;
public class BooksFindByYearRangeSpec : Specification<Book>
{
    public BooksFindByYearRangeSpec(int startYearInclusive, int endYearInclusive)
    {
        Query
            .Where(rs => rs.PublicationYear >= startYearInclusive && rs.PublicationYear <= endYearInclusive)
            .OrderBy(rs => rs.PublicationYear);
    }
}
