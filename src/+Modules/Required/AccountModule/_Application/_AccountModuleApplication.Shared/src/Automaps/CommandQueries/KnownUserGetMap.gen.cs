// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownUserGetRequestMap : Profile
{ 
    public override string ProfileName => "KnownUserGetRequestMap";
    
    public KnownUserGetRequestMap()
    {
        CreateMap<KnownUserGetRequest, KnownUserGetQry>()
        .ReverseMap();
    }
}