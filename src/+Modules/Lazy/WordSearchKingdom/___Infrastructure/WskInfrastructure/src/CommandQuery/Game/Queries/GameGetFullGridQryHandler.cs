// ag=no
namespace WskInfrastructure.CommandQuery;
public class GameGetFullGridQryHandler : IRequestHandler<GameGetFullGridQry, Game>
{
    private IRepository<Game> _repository;
    public GameGetFullGridQryHandler(IRepository<Game> repository)
    {
        _repository = repository;
    }

    public async Task<Game> Handle(GameGetFullGridQry qry, CancellationToken cancellationToken)
    {
        var latestGameGridSpec = new GameGetLatestGameGridSpec(qry.Id);
        var latestGame = await _repository.FirstOrDefaultAsync(latestGameGridSpec);
        if(latestGame.GameGrids.Count() == 0)
        {
            latestGame.CreateNewGridVersion(qry.KnownUserId);
        }
        // OrderByDescending doesn't do anything as the created on is not set
        var latestGameGrid = latestGame.GameGrids.OrderByDescending(rs => rs.CreatedOn).FirstOrDefault();

        var gameSpec = new GameGetByGridIdByUserIdFullSpec(latestGameGrid.Id, qry.KnownUserId);
        var game = await _repository.FirstOrDefaultAsync(gameSpec);
        if(game != null && game.GameGrid.GameGridInstance != null)
        {
            return game;
        }

        latestGame.GameGrid.AddGameGridInstance(qry.KnownUserId);  

        await _repository.UpdateAsync(latestGame);
        return latestGame;
    }
}