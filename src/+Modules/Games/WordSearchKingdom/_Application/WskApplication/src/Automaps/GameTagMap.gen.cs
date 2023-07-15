// ag=yes
namespace WskApplication.Automaps; 
public partial class GameTagMap : Profile
{ 
    public override string ProfileName => "GameTagMap";
    
    public GameTagMap()
    {
        CreateMap<GameTag, GameTagViewModel>()
        .ReverseMap();
    }
}