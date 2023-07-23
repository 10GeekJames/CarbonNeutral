// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserGetByEmailAddressQryHandler : IRequestHandler<KnownUserGetByEmailAddressQry, KnownUser>
{
    private IRepository<KnownUser> _repository;
    public KnownUserGetByEmailAddressQryHandler(IRepository<KnownUser> repository) 
    {
        _repository = repository;
    }

    public async Task<KnownUser> Handle(KnownUserGetByEmailAddressQry qry, CancellationToken cancellationToken)
    {
        var spec = new KnownUserGetByEmailAddressSpec(qry.EmailAddress);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}