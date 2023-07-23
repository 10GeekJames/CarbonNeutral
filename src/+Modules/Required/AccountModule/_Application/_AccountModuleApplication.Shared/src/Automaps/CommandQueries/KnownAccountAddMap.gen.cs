// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownAccountAddRequestMap : Profile
{ 
    public override string ProfileName => "KnownAccountAddRequestMap";
    
    public KnownAccountAddRequestMap()
    {
        CreateMap<KnownAccountAddRequest, KnownAccountAddCmd>()
        .ReverseMap();
    }
}