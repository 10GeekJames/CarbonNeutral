// ag=no *******
namespace WskApplication.Automaps; 
public partial class GameCheckWordCoordsRequestMap : Profile
{ 
    public override string ProfileName => "GameCheckWordCoordsRequestMap";
    
    public GameCheckWordCoordsRequestMap()
    {
        CreateMap<GameCheckWordCoordsRequest, GameCheckWordCoordsQry>()
        .ReverseMap();
    }
}