// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class WebsitePageGetByUrlRequestMap : Profile
{ 
    public override string ProfileName => "WebsitePageGetByUrlRequestMap";
    
    public WebsitePageGetByUrlRequestMap()
    {
        CreateMap<WebsitePageGetByUrlRequest, WebsitePageGetByUrlQry>()
        .ReverseMap();
    }
}