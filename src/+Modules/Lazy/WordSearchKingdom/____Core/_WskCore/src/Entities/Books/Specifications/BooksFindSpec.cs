namespace WskCore.Entities;
public class BooksFindSpec : Specification<Book>
{
    public BooksFindSpec(string titleSearch, IEnumerable<string>? authorSearch, IEnumerable<string>? categorySearch, IEnumerable<string>? conditionSearch, int? paginationPage = 0, int? paginationTake = int.MaxValue)
    {
        if (!paginationPage.HasValue)
        {
            paginationPage = 0;
        }
        if (!paginationTake.HasValue)
        {
            paginationTake = int.MaxValue;
        }

        if (titleSearch.Trim() != "")
        {
            Query
                .Where(rs => rs.Title.Contains(titleSearch, StringComparison.OrdinalIgnoreCase));
        }

        if (authorSearch is not null && authorSearch.Any())
        {
            Query
                .Where(s => s.Authors!.Any(author => authorSearch
                    .Any(searchSpec => author.Name.Contains(searchSpec))));
        }

        if (categorySearch is not null && categorySearch.Any())
        {
            Query
                .Where(s => s.BookCategories!.Any(bookCategory => categorySearch
                    .Any(searchSpec => bookCategory.Title.Contains(searchSpec, StringComparison.OrdinalIgnoreCase))));
        }

        if (conditionSearch is not null && conditionSearch.Any())
        {
            Query
                .Where(book => book.BookCopies
                    .Any(searchSpec => conditionSearch
                        .Any(bookCondition => bookCondition.Contains(searchSpec.Condition.ToString(), StringComparison.OrdinalIgnoreCase))));
        }

        Query
            .OrderBy(rs => rs.Title)
            .Skip(paginationPage.Value * paginationTake.Value)
            .Take(paginationTake.Value)
            ;
    }
}
