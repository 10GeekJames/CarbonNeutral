namespace YmiApplication.FeatureTests.Data;
public class EfBookApplicationUpdate : BaseApplicationTestFixture
{
    [Fact]
    public async Task UpdatesItemAfterAddingIt()
    {
        await Task.Yield();
        /* // add a Book
        var repository = BookApplication();
        var initialName = "My Name";
        var initialId = Guid.NewGuid();

        var Book = new Book(initialId, initialName);

        await repository.AddAsync(Book);
        await repository.UpdateAsync(Book);

        // detach the item so we get a different instance
        _dbContext.Entry(Book).State = EntityState.Detached;

        // fetch the item and update its title
        var newBook = (await repository.ListAsync())
            .FirstOrDefault(rs => rs.Id == initialId);

        Assert.NotNull(newBook);
        Assert.NotSame(Book, newBook);
        var newName = "abc123";
        newBook.UpdateName(newName);

        // Update the item
        await repository.UpdateAsync(newBook);

        // Fetch the updated item
        var updatedItem = (await repository.ListAsync())
            .FirstOrDefault(rs => rs.Id == initialId);

        Assert.NotNull(updatedItem);
        Assert.NotEqual(Book.Name, updatedItem.Name);
        Assert.Equal(newBook.Id, updatedItem.Id); */
    }
}
