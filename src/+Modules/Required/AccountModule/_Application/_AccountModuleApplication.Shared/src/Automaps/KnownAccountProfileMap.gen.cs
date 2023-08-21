// ag=yes
namespace AccountModuleApplication.Shared.Automaps; 
public partial class KnownAccountProfileMap : Profile
{ 
    public override string ProfileName => "KnownAccountProfileMap";
    
    public KnownAccountProfileMap()
    {
        CreateMap<KnownAccountProfile, KnownAccountProfileViewModel>()
        .ReverseMap();
    }
}