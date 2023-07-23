// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class WebsitePageUpdateCmd : IRequest<KnownBusinessWebsite>
{
    public WebsitePage WebsitePage { get; set; }
    private WebsitePageUpdateCmd() { }
    public WebsitePageUpdateCmd(WebsitePage websitePage)
    {
        WebsitePage = websitePage;
    }
}
