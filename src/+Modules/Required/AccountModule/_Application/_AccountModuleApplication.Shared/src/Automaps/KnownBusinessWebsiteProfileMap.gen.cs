// ag=no
namespace AccountModuleApplication.Shared.Automaps; 
public partial class KnownBusinessWebsiteProfileMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteProfileMap";
    
    public KnownBusinessWebsiteProfileMap()
    {
        CreateMap<KnownBusinessWebsiteProfile, KnownBusinessWebsiteProfileViewModel>()
        .ForMember(rs=>rs.KnownBusinessWebsite, rs=>rs.Ignore())
        .ReverseMap();
    }
}