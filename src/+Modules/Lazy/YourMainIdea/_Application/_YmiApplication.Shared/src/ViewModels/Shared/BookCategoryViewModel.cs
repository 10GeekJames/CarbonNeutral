namespace YmiApplication.Shared.ViewModels;
public class BookCategoryViewModel : BaseViewModelTracked<Guid>
{
    public string Title { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = new();
}
