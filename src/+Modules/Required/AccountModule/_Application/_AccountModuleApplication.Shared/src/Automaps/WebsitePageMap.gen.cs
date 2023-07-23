// ag=yes
namespace AccountModuleApplication.Shared.Automaps; 
public partial class WebsitePageMap : Profile
{ 
    public override string ProfileName => "WebsitePageMap";
    
    public WebsitePageMap()
    {
        CreateMap<WebsitePage, WebsitePageViewModel>()
        .ReverseMap();
    }
}