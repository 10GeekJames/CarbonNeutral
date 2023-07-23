// ag=yes
namespace WskApplication.Automaps; 
public partial class GamesGetAllRequestMap : Profile
{ 
    public override string ProfileName => "GamesGetAllRequestMap";
    
    public GamesGetAllRequestMap()
    {
        CreateMap<GamesGetAllRequest, GamesGetAllQry>()
        .ReverseMap();
    }
}