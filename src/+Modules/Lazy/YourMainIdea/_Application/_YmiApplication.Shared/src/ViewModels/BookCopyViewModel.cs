namespace YmiApplication.Shared.ViewModels;
public class BookCopyViewModel : BaseViewModelTracked<Guid>
{
    public BookViewModel Book { get; set; } = new();
    public int CopySequence { get; set; } = -1;
    public BookCondition Condition { get; set; } = BookCondition.New;

}
