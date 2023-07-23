// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessWebsiteProfileUpdateRequestMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteProfileUpdateRequestMap";
    
    public KnownBusinessWebsiteProfileUpdateRequestMap()
    {
        CreateMap<KnownBusinessWebsiteProfileUpdateRequest, KnownBusinessWebsiteProfileUpdateCmd>()
        .ReverseMap();
    }
}