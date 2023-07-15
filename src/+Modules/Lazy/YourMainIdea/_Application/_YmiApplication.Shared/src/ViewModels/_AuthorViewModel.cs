namespace YmiApplication.Shared.ViewModels;
public class AuthorViewModel : BaseViewModelTracked<Guid>
{
    public NameVOViewModel Name { get; set; } = new();

}
