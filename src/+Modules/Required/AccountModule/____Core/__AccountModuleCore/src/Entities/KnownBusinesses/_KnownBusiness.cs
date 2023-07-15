namespace AccountModuleCore.Entities;
public class KnownBusiness : BaseEntity<Guid>, IAggregateRoot
{
    private KnownBusiness() { }
    public KnownBusiness(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public KnownBusiness(Guid id, string name) : this(name)
    {
        Id = Guard.Against.NullOrEmpty(id, nameof(id));
    }


    [MaxLength(101)]
    public string Name { get; private set; } = "";


    [MaxLength(200)]
    public string Industry { get; private set; } = "";
    public ValidStateCodes? StateCode { get; set; }

    // public void SetKnownBusiness(string name, string industry, ValidStateCodes? stateCode)
    // {
    //     Name = Guard.Against.NullOrEmpty(name, nameof(name));
    //     Industry = Guard.Against.NullOrEmpty(industry, nameof(industry));
    //     StateCode = stateCode;
    // }
    public bool IsActive { get; private set; } = true;

    public Guid? ParentBusinessId { get; private set; }
    public KnownBusiness? ParentBusiness { get; private set; } = null;

    private readonly List<KnownBusinessProfile> _knownBusinessProfiles = new();
    public IEnumerable<KnownBusinessProfile> KnownBusinessProfiles => _knownBusinessProfiles;

    private readonly List<KnownBusinessWebsite?> _knownBusinessWebsites = new();
    public IEnumerable<KnownBusinessWebsite?> KnownBusinessWebsites => _knownBusinessWebsites;

    private readonly List<KnownBusiness> _childBusinesses = new();
    public IEnumerable<KnownBusiness> ChildBusinesses => _childBusinesses;

    public void SetActive()
    {
        IsActive = true;
    }
    public void SetInactive()
    {
        IsActive = false;
    }
    public void SetId(Guid id)
    {
        Id = Guard.Against.NullOrEmpty(id, nameof(id));
    }

    public void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public void SetIndustry(string industry)
    {
        Industry = Guard.Against.NullOrEmpty(industry, nameof(industry));
    }

    public void SetParentBusinessId(Guid parentBusinessId)
    {
        ParentBusinessId = Guard.Against.NullOrEmpty(parentBusinessId, nameof(parentBusinessId));
    }
    public void SetParentBusiness(KnownBusiness parentBusiness)
    {
        ParentBusiness = Guard.Against.Null(parentBusiness, nameof(parentBusiness));
    }

    public void AddKnownBusinessWebsite(KnownBusinessWebsite? knownBusinessWebsite)
    {
        if (!_knownBusinessWebsites.Any(rs => rs.Name == knownBusinessWebsite.Name))
        {
            _knownBusinessWebsites.Add(knownBusinessWebsite);
        }
    }

    public void AddChildBusiness(KnownBusiness knownBusiness)
    {
        if (!_childBusinesses.Any(rs => rs.Name == knownBusiness.Name))
        {
            _childBusinesses.Add(knownBusiness);
        }
    }

}
