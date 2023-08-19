// ag=yes
namespace WskApplication.Automaps; 
public partial class GameGetFullGridRequestMap : Profile
{ 
    public override string ProfileName => "GameGetFullGridRequestMap";
    
    public GameGetFullGridRequestMap()
    {
        CreateMap<GameGetFullGridRequest, GameGetFullGridCmd>()
        .ReverseMap();
    }
}