// ag=yes
namespace WskApplication.Shared.Automaps; 
public partial class HiddenWordMap : Profile
{ 
    public override string ProfileName => "HiddenWordMap";
    
    public HiddenWordMap()
    {
        CreateMap<HiddenWord, HiddenWordViewModel>()
        .ReverseMap();
    }
}