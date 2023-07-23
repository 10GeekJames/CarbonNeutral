// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserCreateByUserIdCmd : IRequest<KnownUser>
{
    private KnownUserCreateByUserIdCmd()
    { }
    public KnownUserCreateByUserIdCmd(Guid knownUserId, Guid knownBusinessWebsiteId)
    {
        KnownUserId = Guard.Against.NullOrEmpty(knownUserId);
        KnownBusinessWebsiteId = knownBusinessWebsiteId;
    }
    public Guid KnownUserId { get; set; }
    public Guid KnownBusinessWebsiteId { get; set; }
}
