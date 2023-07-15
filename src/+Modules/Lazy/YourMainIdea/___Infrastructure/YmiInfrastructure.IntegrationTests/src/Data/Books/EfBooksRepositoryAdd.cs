namespace YmiInfrastructure.IntegrationTests.Data.Books;
public class EfBookRepositoryAdd : BaseTestFixture
{
    [Fact]
    public async Task AddsBookSetsId()
    {
        var repository = BookRepository();
        var Book = BookYmiTestData.BookAlfradoTheGreat;

        await repository.AddAsync(Book);

        var newBook = (await repository.ListAsync())
                        .FirstOrDefault();

        Assert.NotNull(newBook?.Id);
    }
}
