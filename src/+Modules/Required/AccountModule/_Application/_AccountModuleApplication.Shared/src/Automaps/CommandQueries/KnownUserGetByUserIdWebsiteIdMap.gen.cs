// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownUserGetByUserIdWebsiteIdRequestMap : Profile
{ 
    public override string ProfileName => "KnownUserGetByUserIdWebsiteIdRequestMap";
    
    public KnownUserGetByUserIdWebsiteIdRequestMap()
    {
        CreateMap<KnownUserGetByUserIdWebsiteIdRequest, KnownUserGetByUserIdWebsiteIdQry>()
        .ReverseMap();
    }
}