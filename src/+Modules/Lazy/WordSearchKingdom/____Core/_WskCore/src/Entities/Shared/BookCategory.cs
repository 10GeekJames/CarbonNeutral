namespace WskCore.Entities;
public class BookCategory : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private BookCategory(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public BookCategory(string title)
    {
        Title = title;
    }
    private List<BookCategory> _bookCategories = new();
    public IEnumerable<BookCategory> BookCategories => _bookCategories.AsReadOnly();
}
