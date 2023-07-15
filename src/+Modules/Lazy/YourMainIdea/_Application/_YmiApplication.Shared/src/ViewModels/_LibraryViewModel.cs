namespace YmiApplication.Shared.ViewModels;
public class LibraryViewModel : BaseViewModelTracked<Guid>
{
    public string Name { get; set; } = "";
    public PhysicalAddressVOViewModel Address { get; set; } = new();
    public List<BookViewModel> Books { get; set; } = new();
}
