// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessWebsiteAliasMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteAliasMap";
    
    public KnownBusinessWebsiteAliasMap()
    {
        CreateMap<KnownBusinessWebsiteAlias, KnownBusinessWebsiteAliasViewModel>()
        .ReverseMap();
    }
}