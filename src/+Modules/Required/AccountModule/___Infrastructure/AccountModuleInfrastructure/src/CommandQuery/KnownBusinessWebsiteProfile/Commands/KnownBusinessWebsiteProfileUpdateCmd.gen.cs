// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessWebsiteProfileUpdateCmd : IRequest<KnownBusinessWebsiteProfile>
{
    public KnownBusinessWebsiteProfile KnownBusinessWebsiteProfile { get; set; }
    private KnownBusinessWebsiteProfileUpdateCmd() 
    { }
    public KnownBusinessWebsiteProfileUpdateCmd(KnownBusinessWebsiteProfile knownBusinessWebsiteProfile)
    {
        KnownBusinessWebsiteProfile = knownBusinessWebsiteProfile;
    }
}
