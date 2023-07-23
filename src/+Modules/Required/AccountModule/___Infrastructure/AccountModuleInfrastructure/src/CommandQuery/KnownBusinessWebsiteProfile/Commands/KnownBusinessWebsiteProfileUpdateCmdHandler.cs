namespace AccountModuleInfrastructure.CommandQuery; 
public class KnownBusinessWebsiteProfileUpdateCmdHandler : IRequestHandler<KnownBusinessWebsiteProfileUpdateCmd, KnownBusinessWebsiteProfile>
{

    private readonly IRepository<KnownBusinessWebsite> _repository;
    public KnownBusinessWebsiteProfileUpdateCmdHandler(IRepository<KnownBusinessWebsite> repository)
    {
        _repository = repository;
    }
    public async Task<KnownBusinessWebsiteProfile> Handle(KnownBusinessWebsiteProfileUpdateCmd cmd, CancellationToken cancellationToken)
    {
        var knownBusinessWebsiteSpec = new KnownBusinessWebsiteGetByIdSpec(cmd.KnownBusinessWebsiteProfile.KnownBusinessWebsiteId);
        var knownBusinessWebsite = await _repository.FirstOrDefaultAsync(knownBusinessWebsiteSpec, cancellationToken);


        cmd.KnownBusinessWebsiteProfile.CopyPropertiesToNoIds(knownBusinessWebsite.KnownBusinessWebsiteProfile);

        await _repository.SaveChangesAsync(cancellationToken);
        return knownBusinessWebsite.KnownBusinessWebsiteProfile;
    }
}
