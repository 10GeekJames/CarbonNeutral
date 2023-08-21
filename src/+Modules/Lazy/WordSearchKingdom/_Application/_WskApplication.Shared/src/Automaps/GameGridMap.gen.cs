// ag=no
namespace WskApplication.Shared.Automaps; 
public partial class GameGridMap : Profile
{ 
    public override string ProfileName => "GameGridMap";
    
    public GameGridMap()
    {
        CreateMap<GameGrid, GameGridViewModel>()
        .ForMember(d => d.Game, o => o.Ignore());
        
        CreateMap<GameGridViewModel, GameGrid>()
        .ForMember(d => d.Game, o => o.Ignore());
    }
}