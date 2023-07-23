// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserGetByUserIdWebsiteIdQryHandler : IRequestHandler<KnownUserGetByUserIdWebsiteIdQry, KnownUser>
{
    private IRepository<KnownUser> _repository;
    public KnownUserGetByUserIdWebsiteIdQryHandler(IRepository<KnownUser> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownUser> Handle(KnownUserGetByUserIdWebsiteIdQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownUserGetByUserIdWebsiteIdSpec(qry.KnownUserId,qry.KnownBusinessWebsiteId);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}