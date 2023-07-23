// ag=yes
namespace WskApplication.Shared.Automaps; 
public partial class GameGridMap : Profile
{ 
    public override string ProfileName => "GameGridMap";
    
    public GameGridMap()
    {
        CreateMap<GameGrid, GameGridViewModel>()
        .ReverseMap();
    }
}