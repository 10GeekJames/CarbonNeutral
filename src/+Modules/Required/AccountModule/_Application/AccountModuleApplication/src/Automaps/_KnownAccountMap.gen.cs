// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownAccountMap : Profile
{ 
    public override string ProfileName => "KnownAccountMap";
    
    public KnownAccountMap()
    {
        CreateMap<KnownAccount, KnownAccountViewModel>()
        .ReverseMap();
    }
}