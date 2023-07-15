namespace AccountModuleCore.Entities;
public class KnownBusinessWebsiteAlias : BaseEntityTracked<Guid>, IAggregateRoot
{
#pragma warning disable CS8618
    private KnownBusinessWebsiteAlias() { }
#pragma warning restore CS8618

    public KnownBusinessWebsiteAlias(KnownBusinessWebsite knownBusinessWebsite, string url, string name)
    {
        Url = Guard.Against.NullOrEmpty(url, nameof(url));
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
        KnownBusinessWebsite = Guard.Against.Null(knownBusinessWebsite);
    }

    public KnownBusinessWebsiteAlias(KnownBusinessWebsite knownBusinessWebsite, Guid id, string url, string name) : this(knownBusinessWebsite, url, name)
    {
        Id = Guard.Against.NullOrEmpty(id, nameof(id));
    }

    public KnownBusinessWebsite KnownBusinessWebsite { get; init; }

    public string Url { get; init; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;

    public void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }

    public void Inactivate()
    {
        IsActive = false;
    }
    public void Activate()
    {
        IsActive = true;
    }
}