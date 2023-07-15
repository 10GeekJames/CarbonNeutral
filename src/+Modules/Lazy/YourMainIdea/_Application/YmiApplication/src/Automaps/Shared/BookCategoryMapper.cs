namespace YmiApplication.Automaps;
public class BookCategoryMapper : Profile
{
    public override string ProfileName
    {
        get { return "BookCategory Map"; }
    }

    public BookCategoryMapper()
    {
        CreateMap<BookCategory, BookCategoryViewModel>();
    }
}