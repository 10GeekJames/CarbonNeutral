// ag=no
namespace WskInfrastructure.CommandQuery; 
public partial class GamesGetAllQryHandler : IRequestHandler<GamesGetAllQry, List<Game>>
{
    private IRepository<Game> _repository;
    public GamesGetAllQryHandler(IRepository<Game> repository) 
    {
        _repository = repository;
    }

    public async Task<List<Game>> Handle(GamesGetAllQry qry, CancellationToken cancellationToken)
    {
        var spec = new GamesGetAllSpec(qry.KnownUserId.Value);
        return await _repository.ListAsync(spec, cancellationToken);
    }
}