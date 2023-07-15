namespace WskCore.WskTestData.Requests;
public class BooksFindWskTestData : IWskTestData
{
    public BooksFindSpec FindByTitleSpec { get; set; }
    public BooksFindSpec FindByTitleAndAuthorsSpec { get; set; }
    public BooksFindSpec FindByTitleAndAuthorsAndCategoriesSpec { get; set; }

    public IEnumerable<BooksFindSpec> AllBooksFindSpecs { get; set; }

    public BooksFindWskTestData()
    {
        FindByTitleSpec = new BooksFindSpec("alf", null, null, null);
        FindByTitleAndAuthorsSpec = new BooksFindSpec("a", new List<string> { "a" }, null, null);
        FindByTitleAndAuthorsAndCategoriesSpec = new BooksFindSpec("a", new List<string> { "a" }, new List<string> { "a" }, null);

        AllBooksFindSpecs = new List<BooksFindSpec> {
            FindByTitleSpec,
            FindByTitleAndAuthorsSpec,
            FindByTitleAndAuthorsAndCategoriesSpec
        };
    }
}
