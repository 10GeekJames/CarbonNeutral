namespace AccountModuleInfrastructure.CommandQuery; 
public class KnownBusinessWebsiteUpdateCmdHandler : IRequestHandler<KnownBusinessWebsiteUpdateCmd, KnownBusinessWebsite>
{
    private readonly IRepository<KnownBusinessWebsite> _repository;
    public KnownBusinessWebsiteUpdateCmdHandler(IRepository<KnownBusinessWebsite> repository)
    {
        _repository = repository;
    }
    public async Task<KnownBusinessWebsite> Handle(KnownBusinessWebsiteUpdateCmd cmd, CancellationToken cancellationToken)
    {
        var newData = cmd.KnownBusinessWebsite;
        var knownBusinessWebsiteSpec = new KnownBusinessWebsiteGetByIdSpec(newData.Id);
        var knownBusinessWebsite = await _repository.FirstOrDefaultAsync(knownBusinessWebsiteSpec, cancellationToken);
        knownBusinessWebsite?.SetKnownBusinessWebsiteProfile(newData.KnownBusinessWebsiteProfile);
        await _repository.SaveChangesAsync(cancellationToken);
        return newData;
    }
}
