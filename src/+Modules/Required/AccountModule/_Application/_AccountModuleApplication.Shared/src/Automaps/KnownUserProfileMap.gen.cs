// ag=no
namespace AccountModuleApplication.Shared.Automaps; 
public partial class KnownUserProfileMap : Profile
{ 
    public override string ProfileName => "KnownUserProfileMap";
    
    public KnownUserProfileMap()
    {
        CreateMap<KnownUserProfile, KnownUserProfileViewModel>()
        .ForMember(rs=>rs.KnownUser, rs=>rs.Ignore())
        .ReverseMap();
    }
}