namespace YmiApplication.Automaps;
public class DigitalAddressVOMapper : Profile
{
    public override string ProfileName
    {
        get { return "DigitalAddressVO Map"; }
    }

    public DigitalAddressVOMapper()
    {
        CreateMap<DigitalAddressVO, DigitalAddressVOViewModel>();
    }
}