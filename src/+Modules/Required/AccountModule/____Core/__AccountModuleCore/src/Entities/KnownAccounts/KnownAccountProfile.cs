namespace AccountModuleCore.Entities;
public class KnownAccountProfile : BaseEntityTracked<Guid>
{
    private KnownAccountProfile() { }
    public KnownAccountProfile(KnownAccount? knownAccount, string name)
    {
        KnownAccount = knownAccount;
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }
    public KnownAccountProfile(Guid id, KnownAccount? knownAccount, string name) : this(knownAccount, name) 
    {
        Id = Guard.Against.NullOrEmpty(id);
    }
    public KnownAccountProfile(Guid id, string name) : this(null, name)
    {
        Id = Guard.Against.NullOrEmpty(id);
    }

    public Guid KnownAccountId { get; private set; }
    public KnownAccount KnownAccount { get; private set; }


    [MaxLength(101)]
    public string Name { get; private set; } = String.Empty;

    public void SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
    }

}
