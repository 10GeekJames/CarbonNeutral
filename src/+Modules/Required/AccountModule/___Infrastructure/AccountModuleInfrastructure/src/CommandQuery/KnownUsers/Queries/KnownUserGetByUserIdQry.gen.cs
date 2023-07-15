// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserGetByUserIdQry : IRequest<KnownUser>
{
    public Guid UserId { get; set; }
    private KnownUserGetByUserIdQry()
    { 
    }
    public KnownUserGetByUserIdQry(Guid userId)
    {
        UserId = Guard.Against.NullOrEmpty(userId);
    }    
}
