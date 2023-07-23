// ag=yes
namespace WskApplication.Automaps; 
public partial class GameCreateNewRequestMap : Profile
{ 
    public override string ProfileName => "GameCreateNewRequestMap";
    
    public GameCreateNewRequestMap()
    {
        CreateMap<GameCreateNewRequest, GameCreateNewCmd>()
        .ReverseMap();
    }
}