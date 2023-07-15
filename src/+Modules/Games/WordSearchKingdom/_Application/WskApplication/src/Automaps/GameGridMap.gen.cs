// ag=yes
namespace WskApplication.Automaps; 
public partial class GameGridMap : Profile
{ 
    public override string ProfileName => "GameGridMap";
    
    public GameGridMap()
    {
        CreateMap<GameGrid, GameGridViewModel>()
        .ReverseMap();
    }
}