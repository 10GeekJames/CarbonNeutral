namespace AccountModuleApplication.Shared.ViewModels;
public partial class WebsitePageViewModel
{
    public bool IsExpanded { get; set; } = false;
    public string WebPageUrlPageOnly
    {
        get
        {
            return WebPageUrl.Replace("/", "*");
        }
    }
   /*  public void UpdateContent(string content)
    {
        this.WebsitePageContent = content;
    }
    public void UpdateValues(WebsitePageViewModel websitePage)
    {
        this.WebPageUrl = websitePage.WebPageUrl;
        this.IsInNavigation = websitePage.IsInNavigation;
        this.IsVirtual = websitePage.IsVirtual;
        this.NavText = websitePage.NavText;
        this.NavIcon = websitePage.NavIcon;
        this.PageTitle = websitePage.PageTitle;
        this.WebsitePageContent = websitePage.WebsitePageContent;
    } */
}