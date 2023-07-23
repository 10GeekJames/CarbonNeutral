// ag=yes
namespace WskInfrastructure.CommandQuery; 
public class GameRecreateGridCmdHandler : IRequestHandler<GameRecreateGridCmd, Game>
{
    private IRepository<Game> _repository;
    public GameRecreateGridCmdHandler(IRepository<Game> repository) 
    {
        _repository = repository;
    }

    public async Task<Game> Handle(GameRecreateGridCmd cmd, CancellationToken cancellationToken)
    {
        var gameSpec = new GameGetByIdSpec(cmd.Id);
        var game = await _repository.FirstOrDefaultAsync(gameSpec);
        game.RecreateGrid();
        await _repository.UpdateAsync(game);
        return game;
    }
}