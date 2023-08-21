// ag=no
namespace AccountModuleApplication.Shared.Automaps; 
public partial class KnownBusinessWebsiteMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteMap";
    
    public KnownBusinessWebsiteMap()
    {
        CreateMap<KnownBusinessWebsite, KnownBusinessWebsiteViewModel>()
        .ForMember(rs=>rs.KnownBusiness, rs=>rs.Ignore())
        .ReverseMap();
    }
}