namespace YmiApplication.FeatureTests.Data;
public class EfBookApplicationDelete : BaseApplicationTestFixture
{
    [Fact]
    public async Task DeletesItemAfterAddingIt()
    {
        await Task.Yield();
        /*   // add a Book
          var repository = BookApplication();
          var initialName = "My Name";
          var initialId = Guid.NewGuid();

          var Book = new Book(initialId, initialName);
          await repository.AddAsync(Book);

          // delete the item
          await repository.DeleteAsync(Book);

          // verify it's no longer there
          Assert.DoesNotContain(await repository.ListAsync(),
              Book => Book.Id == initialId); */
    }
}
