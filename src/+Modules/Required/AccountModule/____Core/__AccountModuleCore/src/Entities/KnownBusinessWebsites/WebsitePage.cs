namespace AccountModuleCore.Entities;
public class WebsitePage : BaseEntityTracked<Guid>
{
    private WebsitePage() { }
    public WebsitePage(KnownBusinessWebsite? knownBusinessWebsite, string webPageUrl, string pageTitle, bool isInNavigation, bool isVirtual, string navIcon, string navText, string? websitePageContent = "")
    {
        KnownBusinessWebsite = knownBusinessWebsite;
        WebPageUrl = webPageUrl;
        PageTitle =  Guard.Against.NullOrEmpty(pageTitle);
        IsInNavigation = isInNavigation;
        IsVirtual = isVirtual;
        NavIcon = Guard.Against.NullOrEmpty(navIcon);
        NavText =  Guard.Against.NullOrEmpty(navText);
        WebsitePageContent = websitePageContent;
    }
    public WebsitePage(Guid id, KnownBusinessWebsite? knownBusinessWebsite, string webPageUrl, string pageTitle, bool isInNavigation, bool isVirtual, string navIcon, string navText, string? websitePageContent = "") : this(knownBusinessWebsite, webPageUrl, pageTitle, isInNavigation, isVirtual, navIcon, navText, websitePageContent)
    {
        Id = Guard.Against.NullOrEmpty(id);
    }
    public Guid? WebsiteParentPageId { get; private set; } = null;
    public WebsitePage? WebsiteParentPage { get; private set; }
    [MaxLength(1000)]
    public string WebsitePageContent { get; private set; } = String.Empty;
    private readonly List<WebsitePage> _websiteChildPages = new();
    public IEnumerable<WebsitePage> WebsiteChildPages => _websiteChildPages.AsReadOnly();
    public KnownBusinessWebsite? KnownBusinessWebsite { get; private set; }
    private readonly List<WebsitePageContent> _websitePageContents = new();
    public IEnumerable<WebsitePageContent> WebsitePageContents => _websitePageContents.AsReadOnly();
    [MaxLength(1000)]
    public string WebPageUrl { get; set; } = String.Empty;
    public bool IsVirtual { get; set; } = true;
    public bool IsInNavigation { get; set; } = false;
    [MaxLength(100)]
    public string PageTitle { get; set; } = "";
    [MaxLength(100)]
    public string NavText { get; set; } = "";
    [MaxLength(100)]
    public string NavIcon { get; set; } = "";

    public void SetWebsitePageContent(string content) {
        WebsitePageContent = content;
    }
    public void AddWebPageContent(WebsitePageContent websitePageContent)
    {
        if (!_websitePageContents.Contains(websitePageContent))
        {
            _websitePageContents.Add(websitePageContent);
        }
    }
    public void RemoveWebPageContent(WebsitePageContent websitePageContent)
    {
        if (_websitePageContents.Contains(websitePageContent))
        {
            _websitePageContents.Remove(websitePageContent);
        }
    }
    public void AddChildPage(WebsitePage websitePage)
    {
        if (!_websiteChildPages.Contains(websitePage))
        {
            _websiteChildPages.Add(websitePage);
        }
    }
    public void AddChildPages(List<WebsitePage> websitePages)
    {
        foreach (var websitePage in websitePages)
        {
            AddChildPage(websitePage);
        }
    }
    public void AddToNavigation()
    {
        IsInNavigation = true;
    }
    public void HideFromNavigation()
    {
        IsInNavigation = false;
    }
}