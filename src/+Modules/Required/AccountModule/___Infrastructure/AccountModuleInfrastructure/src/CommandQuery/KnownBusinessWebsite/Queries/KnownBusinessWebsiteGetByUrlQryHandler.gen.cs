// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessWebsiteGetByUrlQryHandler : IRequestHandler<KnownBusinessWebsiteGetByUrlQry, KnownBusinessWebsite>
{
    private IRepository<KnownBusinessWebsite> _repository;
    public KnownBusinessWebsiteGetByUrlQryHandler(IRepository<KnownBusinessWebsite> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownBusinessWebsite> Handle(KnownBusinessWebsiteGetByUrlQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownBusinessWebsiteGetByUrlSpec(qry.Url);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}