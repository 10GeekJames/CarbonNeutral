namespace AccountModuleInfrastructure.CommandQuery; 
public class KnownUserUpdateAccountCmdHandler : IRequestHandler<KnownUserUpdateAccountCmd, KnownUser>
{
    private readonly IRepository<KnownUser> _repository;
    public KnownUserUpdateAccountCmdHandler(IRepository<KnownUser> repository)
    {
        _repository = repository;
    }
    public async Task<KnownUser> Handle(KnownUserUpdateAccountCmd cmd, CancellationToken cancellationToken)
    {
        var knownUserSpec = new KnownUserGetByUserIdSpec(cmd.UserId);
        var user = await _repository.FirstOrDefaultAsync(knownUserSpec, cancellationToken);
        if (user != null)
        {
            user.SetName(cmd.Name);
            user.SetEmail(cmd.EmailAddress);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        if (user != null) return user;
        return user!;
    }
}