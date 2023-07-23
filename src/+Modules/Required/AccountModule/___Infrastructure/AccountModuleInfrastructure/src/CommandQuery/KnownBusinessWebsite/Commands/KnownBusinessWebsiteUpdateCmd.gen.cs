// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessWebsiteUpdateCmd : IRequest<KnownBusinessWebsite>
{
    public KnownBusinessWebsite KnownBusinessWebsite { get; set; }
    private KnownBusinessWebsiteUpdateCmd() { }
    public KnownBusinessWebsiteUpdateCmd(KnownBusinessWebsite website)
    {
        KnownBusinessWebsite = website;
    }
}
