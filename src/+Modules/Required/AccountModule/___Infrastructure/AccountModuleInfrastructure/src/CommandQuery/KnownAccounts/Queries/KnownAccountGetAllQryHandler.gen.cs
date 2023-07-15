// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownAccountGetAllQryHandler : IRequestHandler<KnownAccountGetAllQry, List<KnownAccount>>
{
    private IRepository<KnownAccount> _repository;
    public KnownAccountGetAllQryHandler(IRepository<KnownAccount> repository) 
    {
        _repository = repository;
    }

    public async Task<List<KnownAccount>> Handle(KnownAccountGetAllQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownAccountGetAllSpec();
        return await _repository.ListAsync(spec, cancellationToken);
    }
}