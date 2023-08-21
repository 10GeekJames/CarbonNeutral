// ag=yes
namespace WskApplication.Automaps; 
public partial class GameGetByIdRequestMap : Profile
{ 
    public override string ProfileName => "GameGetByIdRequestMap";
    
    public GameGetByIdRequestMap()
    {
        CreateMap<GameGetByIdRequest, GameGetByIdQry>()
        .ReverseMap();
    }
}