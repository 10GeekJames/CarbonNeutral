// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownAccountGetByEmailQryHandler : IRequestHandler<KnownAccountGetByEmailQry, KnownAccount>
{
    private IRepository<KnownAccount> _repository;
    public KnownAccountGetByEmailQryHandler(IRepository<KnownAccount> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownAccount> Handle(KnownAccountGetByEmailQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownAccountGetByEmailSpec(qry.EmailAddress);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}