namespace AccountModuleCore.Entities;
public class KnownAccountSubscription : BaseEntityTracked<Guid>
{
    public KnownAccountSubscription() { }
    public KnownAccountSubscription(Guid id) : this()
    {
        Id = id;
    }
}
