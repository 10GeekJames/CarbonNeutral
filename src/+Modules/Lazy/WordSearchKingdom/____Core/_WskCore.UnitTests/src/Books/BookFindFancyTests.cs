
namespace WskCore.UnitTests;

public class BookFindFancyTests : BaseBooksTest
{
    [Theory]
    [MemberData(nameof(GetPaginationTestScenarios))]
    [MemberData(nameof(GetAuthorSearchingTestScenarios))]
    [MemberData(nameof(GetBasicSearchingTestScenarios))]
    [MemberData(nameof(GetCategorySearchTestScenarios))]
    [MemberData(nameof(GetCombinationTestScenarios))]
    public void CanFindBookByTitle(string testTitle, int expectedResultCount, string titleSearch, IEnumerable<string>? authorSearch, IEnumerable<string>? categorySearch, IEnumerable<string>? conditionSearch, int? paginationPage = 0, int? paginationTake = int.MaxValue)
    {
        // Given I have test data
        var allBooks = BookWskTestData.AllBooks;
        
        // And I build a specification from the theory data
        var findSpec = new BooksFindSpec(titleSearch, authorSearch, categorySearch, conditionSearch, paginationPage, paginationTake);
        
        // when I evaluate the test specification
        _booksToTestWith = findSpec.Evaluate(allBooks).ToList();

        // then any expected result returns not empty
        if(expectedResultCount > 0) {
            _booksToTestWith.Should().NotBeNull(testTitle);
        }

        // and the test results has the correct data
        _booksToTestWith!.Count().Should().Be(expectedResultCount, testTitle);
    }

    public static TheoryData<string, int, string, IEnumerable<string>?, IEnumerable<string>?, IEnumerable<string>?, int?, int?>
    GetPaginationTestScenarios =>
    new()
    {
        { "because should have many where title contains the letter a"
            , BookWskTestData.AllBooks.Count(rs => rs.Title.Contains("a", StringComparison.OrdinalIgnoreCase)), "a", null, null, null, null, null},
        { "because should have many where title contains the letter a skip two take two"
            , BookWskTestData.AllBooks.Where(rs => rs.Title.Contains('a', StringComparison.OrdinalIgnoreCase)).OrderBy(rs => rs.Title).Skip(2).Take(2).Count(), "a", null, null, null, 2, 2},
        { "because should have many where title contains the letter a skip one take three"
            , BookWskTestData.AllBooks.Where(rs => rs.Title.Contains('a', StringComparison.OrdinalIgnoreCase)).OrderBy(rs => rs.Title).Skip(1).Take(3).Count(), "a", null, null, null, 1, 3},
        { "because should have zero where title contains the letter a skip five-hundred take one"
            , 0, "a", null, null, null, 500, 1},
        { "because should have one where title is BookJumpingForJax's title skip zero take int.maxvalue"
            , 1, BookWskTestData.BookJumpingForJax.Title, null, null, null, 0, int.MaxValue }
    };

    public static TheoryData<string, int, string, IEnumerable<string>?, IEnumerable<string>?, IEnumerable<string>?, int?, int?>
    GetBasicSearchingTestScenarios =>
    new()
    {
        { "because should have many where title contains the letter a skip null take null"
            , BookWskTestData.AllBooks.Count(rs => rs.Title.Contains('a', StringComparison.OrdinalIgnoreCase)), "a", null, null, null, null, null},
        { "because should have two where title contains the letter a skip null take two"
            , 2, "a", null, null, null, null, 2},
        { "because should have many where book title = 'fan',  with null authors and null categories"
            , 1, BookWskTestData.BookOfFantasy.Title, null, new List<string> { "fan" }, null, null, null }
    };

    public static TheoryData<string, int, string, IEnumerable<string>?, IEnumerable<string>?, IEnumerable<string>?, int?, int?>
    GetAuthorSearchingTestScenarios =>
    new()
    {
        { "because should have one where BookWithCategories "
            , 1, BookWskTestData.BookWithCategories.Title, BookWskTestData.BookWithCategories.Authors!.Select(rs => rs.Name.ToString()), null, null, null, null},
        { "because should have many where title contains the letter a with author search using partial author names"
            , 1, BookWskTestData.BookWithCategories.Title, BookWskTestData.BookWithCategories.Authors!.Select(rs => rs.Name.ToString().Substring(1, rs.Name.ToString().Length - 1)), null, null, null, null }
    };

    public static TheoryData<string, int, string, IEnumerable<string>?, IEnumerable<string>?, IEnumerable<string>?, int?, int?>
    GetCategorySearchTestScenarios =>
    new()
    {
        { "because should have one where BookOfFantasy with all authors and categories full names"
            , 1, BookWskTestData.BookOfFantasy.Title, BookWskTestData.BookOfFantasy.Authors!.Select(rs => rs.Name.ToString()), BookWskTestData.BookOfFantasy.BookCategories!.Select(rs => rs.Title.ToString()), null, null, null }

    };

    public static TheoryData<string, int, string, IEnumerable<string>?, IEnumerable<string>?, IEnumerable<string>?, int?, int?>
    GetCombinationTestScenarios =>
    new()
    {        
        // Exercise Title, Author, Category combinations of testing
        { "because should have one where BookOfFantasy with all authors and all categories with partial category names"
            , 1, BookWskTestData.BookOfFantasy.Title, BookWskTestData.BookOfFantasy.Authors!.Select(rs => rs.Name.ToString().Substring(1, rs.Name.ToString().Length - 1)), BookWskTestData.BookOfFantasy.BookCategories!.Select(rs => rs.Title.ToString().Substring(1, rs.Title.ToString().Length - 1)), null, null, null},
        { "because should have one where BookOfFantasy with null authors and all categories with partial category names"
            , 1, BookWskTestData.BookOfFantasy.Title, null, BookWskTestData.BookOfFantasy.BookCategories!.Select(rs => rs.Title.ToString().Substring(1, rs.Title.ToString().Length - 1)), null, null, null},
        { "because should have one where BookOfFantasy with all authors partial name search and all categories with partial category name"
            , 1, BookWskTestData.BookOfFantasy.Title, null, null, null, null, null},
        { "because should have many where BookWithCategories with authors full name and all categories full name in good condition"
            , 1, BookWskTestData.BookWithCategories.Title, BookWskTestData.BookWithCategories.Authors!.Select(rs => rs.Name.ToString()), BookWskTestData.BookWithCategories.BookCategories!.Select(rs => rs.Title.ToString()), new List<string> { BookCondition.Good.ToString() }, null, null }
    };
}