namespace YmiApplication.Automaps;
public class AuthorMapper : Profile
{
    public override string ProfileName
    {
        get { return "Author Map"; }
    }

    public AuthorMapper()
    {
        CreateMap<Author, AuthorViewModel>();
    }
}