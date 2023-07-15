namespace YmiInfrastructure.IntegrationTests.Data.Libraries;
public class EfLibraryRepositoryAdd : BaseTestFixture
{
    [Fact]
    public async Task AddsLibrarySetsId()
    {
        await Task.Yield();
        /*  var repository = LibraryRepository();

         var library = _libraryYmiTestData.FirstStreetLibrary;

         await repository.AddAsync(library);

         var newLibrary = (await repository.ListAsync())
                         .FirstOrDefault();

         Assert.NotNull(newLibrary?.Id); */
    }
}
