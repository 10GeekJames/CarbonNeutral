namespace AccountModuleCore.Entities;
public class KnownBusinessWebsite : BaseEntityTracked<Guid>, IAggregateRoot
{
    private KnownBusinessWebsite() { }
    public KnownBusinessWebsite(KnownBusiness? knownBusiness, string url, string name)
    {
        Url = Guard.Against.NullOrEmpty(url, nameof(url));
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
        KnownBusiness = knownBusiness;
    }
    public KnownBusinessWebsite(Guid id, string url, string name)
    {
        Id = Guard.Against.NullOrEmpty(id, nameof(id));
        Url = Guard.Against.NullOrEmpty(url, nameof(url));
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public KnownBusinessWebsite(Guid id, KnownBusiness knownBusiness, string url, string name) : this(knownBusiness, url, name)
    {
        Id = Guard.Against.NullOrEmpty(id, nameof(id));
    }

    [MaxLength(1024)]
    public string Url { get; private set; } = "";
    [MaxLength(101)]
    public string Name { get; private set; } = "";


    public bool IsActive { get; private set; } = true;

    public KnownBusiness KnownBusiness { get; private set; }
    public KnownBusinessWebsiteProfile KnownBusinessWebsiteProfile { get; private set; }
    private readonly List<KnownBusinessWebsiteAlias> _knownBusinessWebsiteAliases = new();
    public IEnumerable<KnownBusinessWebsiteAlias> KnownBusinessWebsiteAliases => _knownBusinessWebsiteAliases.AsReadOnly();
    private readonly List<WebsitePage?> _websitePages = new();
    public IEnumerable<WebsitePage?> WebsitePages => _websitePages.AsReadOnly();
    public void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public void SetUrl(string url)
    {
        Url = Guard.Against.NullOrEmpty(url, nameof(url));
    }
    public void Inactivate()
    {
        IsActive = false;
    }
    public void Activate()
    {
        IsActive = true;
    }
    public void AddKnownBusinessWebsiteAlias(KnownBusinessWebsiteAlias alias)
    {
        if (!_knownBusinessWebsiteAliases.Any(rs => rs.Url == alias.Url))
        {
            _knownBusinessWebsiteAliases.Add(alias);
        }
    }
    public void AddWebsitePage(WebsitePage? websitePage)
    {
        if (!_websitePages.Contains(websitePage))
        {
            _websitePages.Add(websitePage);
        }
    }
    public void AddWebsitePages(List<WebsitePage?> websitePages)
    {
        foreach (var websitePage in websitePages)
        {
            AddWebsitePage(websitePage);
        }
    }
    public void RemoveWebsitePage(WebsitePage? websitePage)
    {
        if (_websitePages.Contains(websitePage))
        {
            _websitePages.Remove(websitePage);
        }
    }

    public void SetKnownBusinessWebsiteProfile(KnownBusinessWebsiteProfile knownBusinessWebsiteProfile)
    {
        Guard.Against.Null(knownBusinessWebsiteProfile);
        if (KnownBusinessWebsiteProfile == null)
        {
            KnownBusinessWebsiteProfile = new(this, "", "", "");
        }
        knownBusinessWebsiteProfile.CopyPropertiesTo(KnownBusinessWebsiteProfile);
    }

    public void SetKnownBusiness(KnownBusiness knownBusiness)
    {
        KnownBusiness = Guard.Against.Null(knownBusiness, nameof(knownBusiness));
    }
}
