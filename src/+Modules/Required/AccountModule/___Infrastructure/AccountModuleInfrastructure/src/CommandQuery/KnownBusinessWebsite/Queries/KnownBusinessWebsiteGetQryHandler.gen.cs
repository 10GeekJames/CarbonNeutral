// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessWebsiteGetQryHandler : IRequestHandler<KnownBusinessWebsiteGetQry, KnownBusinessWebsite>
{
    private IRepository<KnownBusinessWebsite> _repository;
    public KnownBusinessWebsiteGetQryHandler(IRepository<KnownBusinessWebsite> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownBusinessWebsite> Handle(KnownBusinessWebsiteGetQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownBusinessWebsiteGetSpec();
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}