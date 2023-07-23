// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class WebsitePageGetByUrlQryHandler : IRequestHandler<WebsitePageGetByUrlQry, KnownBusinessWebsite>
{
    private IRepository<KnownBusinessWebsite> _repository;
    public WebsitePageGetByUrlQryHandler(IRepository<KnownBusinessWebsite> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownBusinessWebsite> Handle(WebsitePageGetByUrlQry qry, CancellationToken cancellationToken)
    {
        var spec = new WebsitePageGetByUrlSpec(qry.Url);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}