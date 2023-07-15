namespace WskInfrastructure.CommandQuery;

public class GamesGetAllQryHandler : IRequestHandler<GamesGetAllQry, List<Game>>
{
    private readonly IRepository<Game> _repository;
    public GamesGetAllQryHandler(IRepository<Game> repository)
    {
        _repository = repository;
    }
    public async Task<List<Game>> Handle(GamesGetAllQry qry, CancellationToken cancellationToken)
    {
        var gamesGetAllSpec = new GamesGetAllSpec();
        return await _repository.ListAsync(gamesGetAllSpec, cancellationToken);
    }
}