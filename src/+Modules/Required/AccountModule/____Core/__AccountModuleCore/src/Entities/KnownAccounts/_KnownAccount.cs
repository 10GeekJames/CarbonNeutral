namespace AccountModuleCore.Entities;
public class KnownAccount : BaseEntityTracked<Guid>, IAggregateRoot
{
    private KnownAccount() { }
    public KnownAccount(string aliasName, string emailAddress)
    {
        AliasName = Guard.Against.NullOrEmpty(aliasName, nameof(aliasName));
        EmailAddress = Guard.Against.NullOrEmpty(emailAddress, nameof(emailAddress));
    }

    public KnownAccount(Guid id, string aliasName, string emailAddress) : this(aliasName, emailAddress)
    {
        Id = Guard.Against.NullOrEmpty(id, nameof(id));
    }


    [MaxLength(101)]
    public string Name { get; private set; } = "";


    [MaxLength(100)]
    public string? EmailAddress { get; private set; }


    [MaxLength(100)]
    public string? AliasName { get; private set; }

    public bool IsActive { get; private set; } = true;

    public bool IsJokerFlag { get; private set; } = false;

    private readonly List<KnownAccountProfile> _knownAccountProfiles = new();
    public IEnumerable<KnownAccountProfile> KnownAccountProfiles => _knownAccountProfiles.AsReadOnly();

    public void AddKnownAccountProfile(string aliasName)
    {
        Guard.Against.NullOrEmpty(aliasName, nameof(aliasName));
        var profile = new KnownAccountProfile(this, aliasName);
        if (!_knownAccountProfiles.Contains(profile))
        {
            _knownAccountProfiles.Add(profile);
        }
    }
    public void SetAliasName(string aliasName)
    {
        AliasName = Guard.Against.NullOrEmpty(aliasName, nameof(aliasName));
    }
    public void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public void SetJokerFlagToTrue()
    {
        // if we really think its right, probably want to throw some events, do other sophisticated things too.
        IsJokerFlag = true;
    }
    public void SetJokerFlagToFalse()
    {
        // if we really think its right, probably want to throw some events, do other sophisticated things too.
        IsJokerFlag = false;
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
