// ag=yes
namespace WskApplication.Shared.Automaps; 
public partial class GameMap : Profile
{ 
    public override string ProfileName => "GameMap";
    
    public GameMap()
    {
        CreateMap<Game, GameViewModel>()
        .ReverseMap();
    }
}