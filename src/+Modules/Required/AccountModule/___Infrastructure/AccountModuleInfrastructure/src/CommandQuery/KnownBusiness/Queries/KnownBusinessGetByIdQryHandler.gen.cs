// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessGetByIdQryHandler : IRequestHandler<KnownBusinessGetByIdQry, KnownBusiness>
{
    private IRepository<KnownBusiness> _repository;
    public KnownBusinessGetByIdQryHandler(IRepository<KnownBusiness> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownBusiness> Handle(KnownBusinessGetByIdQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownBusinessGetByIdSpec(qry.Id);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}