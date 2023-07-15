// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownAccountProfileMap : Profile
{ 
    public override string ProfileName => "KnownAccountProfileMap";
    
    public KnownAccountProfileMap()
    {
        CreateMap<KnownAccountProfile, KnownAccountProfileViewModel>()
        .ReverseMap();
    }
}