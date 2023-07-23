// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class WebsitePageUpdateRequestMap : Profile
{ 
    public override string ProfileName => "WebsitePageUpdateRequestMap";
    
    public WebsitePageUpdateRequestMap()
    {
        CreateMap<WebsitePageUpdateRequest, WebsitePageUpdateCmd>()
        .ReverseMap();
    }
}