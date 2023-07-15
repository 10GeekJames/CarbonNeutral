namespace YmiApplication.Automaps;
public class BookCopyMapper : Profile
{
    public override string ProfileName
    {
        get { return "BookCopy Map"; }
    }

    public BookCopyMapper()
    {
        CreateMap<BookCopy, BookCopyViewModel>()
        .ForMember(rs => rs.Book, rss => rss.Ignore())
        ;
    }
}