namespace YmiApplication.Shared.ViewModels;
public class BookViewModel : BaseViewModelTracked<Guid>
{
    public IsbnVOViewModel Isbn { get; set; } = new();
    public string Title { get; set; } = string.Empty;
    public int PublicationYear { get; set; }
    public int PageCount { get; set; }

    public List<Author> Authors  { get; set; } = new();
    
    public List<BookCategoryViewModel> BookCategories  { get; set; } = new();
    
    public List<BookCopyViewModel> BookCopies  { get; set; } = new();
    

}
