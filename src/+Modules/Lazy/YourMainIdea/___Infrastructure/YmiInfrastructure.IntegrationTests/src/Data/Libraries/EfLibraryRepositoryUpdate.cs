namespace YmiInfrastructure.IntegrationTests.Data;
public class EfLibraryRepositoryUpdate : BaseTestFixture
{
    [Fact]
    public async Task UpdatesItemAfterAddingIt()
    {
        await Task.Yield();
        /* // add a Library
        var repository = LibraryRepository();
        var initialName = "My Name";
        var initialId = Guid.NewGuid();

        var Library = new Library(initialId, initialName);

        await repository.AddAsync(Library);
        await repository.UpdateAsync(Library);

        // detach the item so we get a different instance
        _dbContext.Entry(Library).State = EntityState.Detached;

        // fetch the item and update its title
        var newLibrary = (await repository.ListAsync())
            .FirstOrDefault(rs => rs.Id == initialId);

        Assert.NotNull(newLibrary);
        Assert.NotSame(Library, newLibrary);
        var newName = "abc123";
        newLibrary.UpdateName(newName);

        // Update the item
        await repository.UpdateAsync(newLibrary);

        // Fetch the updated item
        var updatedItem = (await repository.ListAsync())
            .FirstOrDefault(rs => rs.Id == initialId);

        Assert.NotNull(updatedItem);
        Assert.NotEqual(Library.Name, updatedItem.Name);
        Assert.Equal(newLibrary.Id, updatedItem.Id); */
    }
}
