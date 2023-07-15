namespace AccountModuleCore.Entities;
public class KnownBusinessProfile : BaseEntityTracked<Guid>
{
    private KnownBusinessProfile() { }
    public KnownBusinessProfile(KnownBusiness? knownBusiness, string name)
    {
        KnownBusiness = knownBusiness;
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public KnownBusinessProfile(Guid id, KnownBusiness? knownBusiness, string name) : this(knownBusiness, name)
    {
        Id = id;
    }
    public KnownBusinessProfile(Guid id, string name) : this(null, name)
    {
        Id = id;
    }


    [MaxLength(101)]
    public string Name { get; private set; } = String.Empty;

    public Guid KnownBusinessId { get; private set; }
    public KnownBusiness KnownBusiness { get; private set; }

    public void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
}
