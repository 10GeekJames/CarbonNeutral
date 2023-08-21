// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownAccountsGetAllQryHandler : IRequestHandler<KnownAccountsGetAllQry, List<KnownAccount>>
{
    private IRepository<KnownAccount> _repository;
    public KnownAccountsGetAllQryHandler(IRepository<KnownAccount> repository) 
    {
        _repository = repository;
    }

    public async Task<List<KnownAccount>> Handle(KnownAccountsGetAllQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownAccountsGetAllSpec();
        return await _repository.ListAsync(spec, cancellationToken);
    }
}