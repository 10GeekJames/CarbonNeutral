namespace YmiApplication.Automaps;
public class LibraryMapper : Profile
{
    public override string ProfileName
    {
        get { return "Library Map"; }
    }

    public LibraryMapper()
    {
        CreateMap<Library, LibraryViewModel>();
    }
}