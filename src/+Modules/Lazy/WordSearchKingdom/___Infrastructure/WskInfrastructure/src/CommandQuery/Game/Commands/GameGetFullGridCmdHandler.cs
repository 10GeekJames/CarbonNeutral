// ag=no
namespace WskInfrastructure.CommandQuery;
public class GameGetFullGridCmdHandler : IRequestHandler<GameGetFullGridCmd, Game>
{
    private IRepository<Game> _repository;
    public GameGetFullGridCmdHandler(IRepository<Game> repository)
    {
        _repository = repository;
    }

    public async Task<Game> Handle(GameGetFullGridCmd cmd, CancellationToken cancellationToken)
    {
        var latestGameGridSpec = new GameGetLatestGameGridSpec(cmd.Id);
        var latestGame = await _repository.FirstOrDefaultAsync(latestGameGridSpec);
        var latestGameGrid = latestGame.GameGrids.OrderByDescending(rs => rs.CreatedOn).FirstOrDefault();

        var gameSpec = new GameGetByGridIdByUserIdFullSpec(latestGameGrid.Id, cmd.KnownUserId);
        var game = await _repository.FirstOrDefaultAsync(gameSpec);
        if(game != null && game.GameGrid.GameGridInstance != null)
        {
            return game;
        }

        latestGame.GameGrid.AddGameGridInstance(cmd.KnownUserId);  

        await _repository.UpdateAsync(latestGame);
        return latestGame;
    }
}