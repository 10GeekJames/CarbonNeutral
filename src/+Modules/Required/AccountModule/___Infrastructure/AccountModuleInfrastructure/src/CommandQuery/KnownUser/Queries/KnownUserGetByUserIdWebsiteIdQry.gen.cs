// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserGetByUserIdWebsiteIdQry : IRequest<KnownUser>
{
    public Guid KnownUserId { get; set; }
    public Guid KnownBusinessWebsiteId { get; set; }
    private KnownUserGetByUserIdWebsiteIdQry() { }
    public KnownUserGetByUserIdWebsiteIdQry(Guid knownUserId, Guid knownBusinessWebsiteId)
    {
        KnownUserId = Guard.Against.NullOrEmpty(knownUserId);
        KnownBusinessWebsiteId = knownBusinessWebsiteId;
    }
}
