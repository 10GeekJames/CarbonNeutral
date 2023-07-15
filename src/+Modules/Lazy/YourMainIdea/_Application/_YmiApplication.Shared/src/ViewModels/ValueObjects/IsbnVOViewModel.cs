namespace YmiApplication.Shared.ViewModels;
public class IsbnVOViewModel
{
    public string Isbn { get; set; } = string.Empty;

    public override string ToString()
    {
        return Isbn;
    }
}
