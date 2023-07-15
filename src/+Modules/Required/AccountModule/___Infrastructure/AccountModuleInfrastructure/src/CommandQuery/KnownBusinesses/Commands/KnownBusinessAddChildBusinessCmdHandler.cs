namespace AccountModuleInfrastructure.CommandQuery;
public class KnownBusinessAddChildBusinessCmdHandler : IRequestHandler<KnownBusinessAddChildBusinessCmd, KnownBusiness>
{
    private readonly IRepository<KnownBusiness> _repository;
    public KnownBusinessAddChildBusinessCmdHandler(IRepository<KnownBusiness> repository)
    {
        _repository = repository;
    }
    public async Task<KnownBusiness> Handle(KnownBusinessAddChildBusinessCmd request, CancellationToken cancellationToken)
    {
        var knownAccountGetByIdSpec = new KnownBusinessGetByIdSpec(request.ExistingBusinessId);
        //var knownAccount = await _repository.GetBySpecAsync(knownAccountGetByIdSpec, cancellationToken);
        var knownAccount = await _repository.FirstOrDefaultAsync(knownAccountGetByIdSpec, cancellationToken);
        var newAccount = request.ChildBusiness;
        knownAccount?.AddChildBusiness(newAccount);
        await _repository.SaveChangesAsync(cancellationToken);
        var result =  await _repository.AddAsync(newAccount, cancellationToken);
        return result;
    }
}