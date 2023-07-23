// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownUserUpdateAccountRequestMap : Profile
{ 
    public override string ProfileName => "KnownUserUpdateAccountRequestMap";
    
    public KnownUserUpdateAccountRequestMap()
    {
        CreateMap<KnownUserUpdateAccountRequest, KnownUserUpdateAccountCmd>()
        .ReverseMap();
    }
}