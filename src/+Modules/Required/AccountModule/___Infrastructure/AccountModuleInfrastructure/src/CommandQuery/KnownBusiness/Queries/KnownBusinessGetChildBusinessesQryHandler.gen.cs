// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessGetChildBusinessesQryHandler : IRequestHandler<KnownBusinessGetChildBusinessesQry, List<KnownBusiness>>
{
    private IRepository<KnownBusiness> _repository;
    public KnownBusinessGetChildBusinessesQryHandler(IRepository<KnownBusiness> repository) 
    {
        _repository = repository;
    }

    public async Task<List<KnownBusiness>> Handle(KnownBusinessGetChildBusinessesQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownBusinessGetChildBusinessesSpec(qry.Id);
        return await _repository.ListAsync(spec, cancellationToken);
    }
}