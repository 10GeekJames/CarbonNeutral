namespace WskApplication.FeatureTests.Data.Books;
public class EfBookApplicationAdd : BaseApplicationTestFixture
{
    [Fact]
    public async Task AddBook()
    {

        var result = await _dataService.BooksGetAllAsync(new BooksGetAllQry());
        result!.Count.Should().Be(0, "because we haven't added any books yet");

        var cmd = new BookAddCmd(BookWskTestData.BookAlfradoTheGreat);
        await _dataService.BookAddAsync(cmd);

        var qry = new BooksGetAllQry();
        result = (await _dataService.BooksGetAllAsync(qry));
        var resultFirst = result!.FirstOrDefault();
        var resultFirstCopy = resultFirst?.BookCopies.FirstOrDefault();

        result.Should().NotBeNull("because we just added a book");
        resultFirst!.BookCopies.Count.Should().Be(1, "because we added a single book");

        resultFirst.Isbn.ToString().Should().Be(BookWskTestData.BookAlfradoTheGreat.Isbn.ToString());
        resultFirst.Title.Should().Be(BookWskTestData.BookAlfradoTheGreat.Title);
        resultFirstCopy!.Condition.Should().Be(BookWskTestData.BookAlfradoTheGreat.BookCopies.First().Condition);
    }
}
