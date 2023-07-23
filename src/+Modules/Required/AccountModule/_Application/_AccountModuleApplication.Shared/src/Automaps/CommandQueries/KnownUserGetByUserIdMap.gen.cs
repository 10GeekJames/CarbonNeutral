// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownUserGetByUserIdRequestMap : Profile
{ 
    public override string ProfileName => "KnownUserGetByUserIdRequestMap";
    
    public KnownUserGetByUserIdRequestMap()
    {
        CreateMap<KnownUserGetByUserIdRequest, KnownUserGetByUserIdQry>()
        .ReverseMap();
    }
}