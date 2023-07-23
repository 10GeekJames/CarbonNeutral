// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameGetByIdQryHandler : IRequestHandler<GameGetByIdQry, Game>
{
    private IRepository<Game> _repository;
    public GameGetByIdQryHandler(IRepository<Game> repository) 
    {
        _repository = repository;
    }

    public async Task<Game> Handle(GameGetByIdQry qry, CancellationToken cancellationToken)
    {
        var spec = new GameGetByIdSpec(qry.Id);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}