// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessWebsiteGetByUrlRequestMap : Profile
{ 
    public override string ProfileName => "KnownBusinessWebsiteGetByUrlRequestMap";
    
    public KnownBusinessWebsiteGetByUrlRequestMap()
    {
        CreateMap<KnownBusinessWebsiteGetByUrlRequest, KnownBusinessWebsiteGetByUrlQry>()
        .ReverseMap();
    }
}