// ag=yes
namespace WskApplication.Automaps; 
public partial class GameCheckWordCoordsRequestMap : Profile
{ 
    public override string ProfileName => "GameCheckWordCoordsRequestMap";
    
    public GameCheckWordCoordsRequestMap()
    {
        CreateMap<GameCheckWordCoordsRequest, GameCheckWordCoordsCmd>()
        .ReverseMap();
    }
}