// ag=no
namespace WskApplication.Shared.Automaps; 
public partial class GameGridInstanceMap : Profile
{ 
    public override string ProfileName => "GameGridInstanceMap";
    
    public GameGridInstanceMap()
    {
        CreateMap<GameGridInstance, GameGridInstanceViewModel>()
        .ForMember(d => d.GameGrid, opt => opt.Ignore());
        
        CreateMap<GameGridInstanceViewModel, GameGridInstance>()
        .ForMember(d => d.GameGrid, opt => opt.Ignore());
    }
}