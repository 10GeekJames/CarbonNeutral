namespace AccountModuleInfrastructure.CommandQuery; 
public class KnownUserCreateByUserIdCmdHandler : IRequestHandler<KnownUserCreateByUserIdCmd, KnownUser>
{
    private readonly IRepository<KnownUser> _knownUserRepository;
    private readonly IRepository<KnownBusinessWebsite> _knownBusinessWebsiteRepository;
    public KnownUserCreateByUserIdCmdHandler(IRepository<KnownUser> knownUserRepository, IRepository<KnownBusinessWebsite> knownBusinessWebsiteRepository)
    {
        _knownUserRepository = knownUserRepository;
        _knownBusinessWebsiteRepository = knownBusinessWebsiteRepository;
    }
    public async Task<KnownUser> Handle(KnownUserCreateByUserIdCmd cmd, CancellationToken cancellationToken)
    {
        var knownWebsiteSpec = new KnownBusinessWebsiteGetByIdSpec(cmd.KnownBusinessWebsiteId);
        var knownWebsite = await _knownBusinessWebsiteRepository.FirstOrDefaultAsync(knownWebsiteSpec, cancellationToken);

        var newKnownUser = new KnownUser(cmd.KnownUserId);
        newKnownUser.AddKnownUserProfile(cmd.KnownBusinessWebsiteId, "");

        return await _knownUserRepository.AddAsync(newKnownUser, cancellationToken);
    }
}