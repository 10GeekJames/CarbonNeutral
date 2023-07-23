// ag=yes
namespace WskApplication.Automaps; 
public partial class GameRecreateGridRequestMap : Profile
{ 
    public override string ProfileName => "GameRecreateGridRequestMap";
    
    public GameRecreateGridRequestMap()
    {
        CreateMap<GameRecreateGridRequest, GameRecreateGridCmd>()
        .ReverseMap();
    }
}