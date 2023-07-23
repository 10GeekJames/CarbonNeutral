// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessWebsiteGetRequestMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteGetRequestMap";
    
    public KnownBusinessWebsiteGetRequestMap()
    {
        CreateMap<KnownBusinessWebsiteGetRequest, KnownBusinessWebsiteGetQry>()
        .ReverseMap();
    }
}