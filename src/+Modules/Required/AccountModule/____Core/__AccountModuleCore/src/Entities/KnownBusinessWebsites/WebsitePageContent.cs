namespace AccountModuleCore.Entities;
public class WebsitePageContent : BaseEntityTracked<Guid>
{
    private WebsitePageContent() { }
    public WebsitePageContent(WebsitePage websitePage, Guid id)
    {
        WebsitePage = websitePage;
        Id = id;
    }

    public WebsitePage WebsitePage { get; private set; }


    [MaxLength(65535)]
    public string HtmlContent { get; set; } = "";


}
