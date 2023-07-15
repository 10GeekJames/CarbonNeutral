// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownUserProfileMap : Profile
{ 
    public override string ProfileName => "KnownUserProfileMap";
    
    public KnownUserProfileMap()
    {
        CreateMap<KnownUserProfile, KnownUserProfileViewModel>()
        .ReverseMap();
    }
}