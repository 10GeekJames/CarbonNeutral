// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessWebsiteMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteMap";
    
    public KnownBusinessWebsiteMap()
    {
        CreateMap<KnownBusinessWebsite, KnownBusinessWebsiteViewModel>()
        .ReverseMap();
    }
}