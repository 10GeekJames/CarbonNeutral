namespace AccountModuleInfrastructure.CommandQuery;
public class KnownAccountAddCmdHandler : IRequestHandler<KnownAccountAddCmd, KnownAccount>
{
    private IRepository<KnownAccount> _repository;
    public KnownAccountAddCmdHandler(IRepository<KnownAccount> repository)
    {
        _repository = repository;
    }
    public async Task<KnownAccount> Handle(KnownAccountAddCmd request, CancellationToken cancellationToken)
    {
        var newKnownAccount = new KnownAccount(request.AliasName, request.EmailAddress);
        return await _repository.AddAsync(newKnownAccount, cancellationToken);
    }
}