// ag=yes
namespace WskApplication.Automaps; 
public partial class GameMap : Profile
{ 
    public override string ProfileName => "GameMap";
    
    public GameMap()
    {
        CreateMap<Game, GameViewModel>()
        .ReverseMap();
    }
}