namespace AccountModuleCore.Entities;
public class KnownUserProfile : BaseEntityTracked<Guid>
{
    private KnownUserProfile() { }
    public KnownUserProfile(string name)
    {
        Name = name;
    }

    public KnownUserProfile(Guid knownUserId, Guid knownBusinessWebsiteId, string name) : this(name)
    {
        KnownUserId = knownUserId;
        KnownBusinessWebsiteId = knownBusinessWebsiteId;
    }

    public KnownUserProfile(KnownUser knownUser, Guid knownBusinessWebsiteId, string name) : this(name)
    {
        KnownUser = knownUser;
        KnownBusinessWebsiteId = knownBusinessWebsiteId;
    }

    public KnownUserProfile(Guid id, KnownUser knownUser, KnownBusinessWebsite knownBusinessWebsite, string name) : this(name)
    {
        Id = Guard.Against.NullOrEmpty(id);
        KnownUser = knownUser;
        KnownBusinessWebsite = knownBusinessWebsite;
    }

    
    [MaxLength(101)]
    public string Name { get; private set; } = String.Empty;
    public Guid KnownUserId { get; private set; } = Guid.Empty;
    public KnownUser KnownUser { get; private set; }

    public Guid KnownBusinessWebsiteId { get; private set; } = Guid.Empty;
    public KnownBusinessWebsite KnownBusinessWebsite { get; private set; }

    public void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
}
