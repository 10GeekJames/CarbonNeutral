// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserGetQryHandler : IRequestHandler<KnownUserGetQry, KnownUser>
{
    private IRepository<KnownUser> _repository;
    public KnownUserGetQryHandler(IRepository<KnownUser> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownUser> Handle(KnownUserGetQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownUserGetSpec();
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}