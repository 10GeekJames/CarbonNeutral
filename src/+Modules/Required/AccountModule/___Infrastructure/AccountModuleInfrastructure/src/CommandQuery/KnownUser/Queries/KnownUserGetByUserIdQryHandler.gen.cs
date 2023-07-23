// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserGetByUserIdQryHandler : IRequestHandler<KnownUserGetByUserIdQry, KnownUser>
{
    private IRepository<KnownUser> _repository;
    public KnownUserGetByUserIdQryHandler(IRepository<KnownUser> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownUser> Handle(KnownUserGetByUserIdQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownUserGetByUserIdSpec(qry.UserId);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}