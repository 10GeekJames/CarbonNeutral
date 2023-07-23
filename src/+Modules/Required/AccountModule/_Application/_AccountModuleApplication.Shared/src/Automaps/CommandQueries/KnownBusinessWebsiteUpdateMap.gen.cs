// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessWebsiteUpdateRequestMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteUpdateRequestMap";
    
    public KnownBusinessWebsiteUpdateRequestMap()
    {
        CreateMap<KnownBusinessWebsiteUpdateRequest, KnownBusinessWebsiteUpdateCmd>()
        .ReverseMap();
    }
}