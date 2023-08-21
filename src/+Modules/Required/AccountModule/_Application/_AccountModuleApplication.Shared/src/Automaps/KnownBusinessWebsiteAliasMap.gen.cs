// ag=no
namespace AccountModuleApplication.Shared.Automaps; 
public partial class KnownBusinessWebsiteAliasMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteAliasMap";
    
    public KnownBusinessWebsiteAliasMap()
    {
        CreateMap<KnownBusinessWebsiteAlias, KnownBusinessWebsiteAliasViewModel>()
        .ForMember(rs=>rs.KnownBusinessWebsite, rs=>rs.Ignore())
        .ReverseMap();
    }
}