// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessAddChildBusinessCmd : IRequest<KnownBusiness>
{
    public Guid ExistingBusinessId { get; set; }
    public KnownBusiness ChildBusiness { get; set; }
    private KnownBusinessAddChildBusinessCmd()
    {}
    public KnownBusinessAddChildBusinessCmd(Guid existingBusinessId, KnownBusiness childBusiness)
    {
        ExistingBusinessId = Guard.Against.NullOrEmpty(existingBusinessId, nameof(existingBusinessId));
        ChildBusiness = Guard.Against.Null(childBusiness, nameof(childBusiness));
    }
}
