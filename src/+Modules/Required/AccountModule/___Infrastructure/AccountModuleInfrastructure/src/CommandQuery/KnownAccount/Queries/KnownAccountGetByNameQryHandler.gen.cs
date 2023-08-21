// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownAccountGetByNameQryHandler : IRequestHandler<KnownAccountGetByNameQry, KnownAccount>
{
    private IRepository<KnownAccount> _repository;
    public KnownAccountGetByNameQryHandler(IRepository<KnownAccount> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownAccount> Handle(KnownAccountGetByNameQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownAccountGetByNameSpec(qry.Name);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}