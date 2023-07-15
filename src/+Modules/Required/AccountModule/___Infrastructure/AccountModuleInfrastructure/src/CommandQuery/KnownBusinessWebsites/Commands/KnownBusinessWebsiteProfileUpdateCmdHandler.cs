namespace AccountModuleInfrastructure.CommandQuery; 
public class KnownBusinessWebsiteProfileUpdateCmdHandler : IRequestHandler<KnownBusinessWebsiteProfileUpdateCmd, KnownBusinessWebsiteProfile>
{

    private readonly IRepository<KnownBusinessWebsiteProfile> _knownBusinessWebsiteProfileRepository;
    public KnownBusinessWebsiteProfileUpdateCmdHandler(IRepository<KnownBusinessWebsiteProfile> knownBusinessWebsiteProfileRepository)
    {
        _knownBusinessWebsiteProfileRepository = knownBusinessWebsiteProfileRepository;
    }
    public async Task<KnownBusinessWebsiteProfile> Handle(KnownBusinessWebsiteProfileUpdateCmd cmd, CancellationToken cancellationToken)
    {
        var knownBusinessWebsiteProfileSpec = new KnownBusinessWebsiteProfileGetByIdSpec(cmd.KnownBusinessWebsiteProfile.Id);
        var knownBusinessWebsiteProfile = await _knownBusinessWebsiteProfileRepository.FirstOrDefaultAsync(knownBusinessWebsiteProfileSpec, cancellationToken);

        cmd.KnownBusinessWebsiteProfile.CopyPropertiesToNoIds(knownBusinessWebsiteProfile);

        await _knownBusinessWebsiteProfileRepository.SaveChangesAsync(cancellationToken);
        return knownBusinessWebsiteProfile;
    }
}
