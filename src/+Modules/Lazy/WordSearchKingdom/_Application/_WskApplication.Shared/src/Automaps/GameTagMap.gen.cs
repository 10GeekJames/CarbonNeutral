// ag=yes
namespace WskApplication.Shared.Automaps; 
public partial class GameTagMap : Profile
{ 
    public override string ProfileName => "GameTagMap";
    
    public GameTagMap()
    {
        CreateMap<GameTag, GameTagViewModel>()
        .ReverseMap();
    }
}