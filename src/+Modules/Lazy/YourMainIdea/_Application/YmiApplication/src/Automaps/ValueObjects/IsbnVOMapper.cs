namespace YmiApplication.Automaps;
public class IsbnVOMapper : Profile
{
    public override string ProfileName
    {
        get { return "IsbnVO Map"; }
    }

    public IsbnVOMapper()
    {
        CreateMap<IsbnVO, IsbnVOViewModel>();
    }
}