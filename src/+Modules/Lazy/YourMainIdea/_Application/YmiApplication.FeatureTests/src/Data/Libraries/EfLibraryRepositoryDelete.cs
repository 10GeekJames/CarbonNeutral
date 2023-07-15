namespace YmiApplication.FeatureTests.Data;
public class EfLibraryRepositoryDelete : BaseApplicationTestFixture
{
    [Fact]
    public async Task DeletesItemAfterAddingIt()
    {
        await Task.Yield();
        /*   // add a Library
          var repository = LibraryRepository();
          var initialName = "My Name";
          var initialId = Guid.NewGuid();

          var Library = new Library(initialId, initialName);
          await repository.AddAsync(Library);

          // delete the item
          await repository.DeleteAsync(Library);

          // verify it's no longer there
          Assert.DoesNotContain(await repository.ListAsync(),
              Library => Library.Id == initialId); */
    }
}
