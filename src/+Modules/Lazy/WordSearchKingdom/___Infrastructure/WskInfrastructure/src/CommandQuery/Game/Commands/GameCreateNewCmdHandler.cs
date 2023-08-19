// ag=yes
namespace WskInfrastructure.CommandQuery; 
public class GameCreateNewCmdHandler : IRequestHandler<GameCreateNewCmd, Game>
{
    private IRepository<Game> _repository;
    public GameCreateNewCmdHandler(IRepository<Game> repository) 
    {
        _repository = repository;
    }

    public async Task<Game> Handle(GameCreateNewCmd cmd, CancellationToken cancellationToken)
    {
        var game = new Game(cmd.KnownUserId, cmd.Title, cmd.Height, cmd.Width, cmd.GameDifficulty, cmd.WordsToHide, cmd.GameCategories, cmd.GameTags);
        await _repository.AddAsync(game);
        return game;
    }
}