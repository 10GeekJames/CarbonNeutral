// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownUserCreateByUserIdRequestMap : Profile
{ 
    public override string ProfileName => "KnownUserCreateByUserIdRequestMap";
    
    public KnownUserCreateByUserIdRequestMap()
    {
        CreateMap<KnownUserCreateByUserIdRequest, KnownUserCreateByUserIdCmd>()
        .ReverseMap();
    }
}