namespace WskCore.Entities;

public class Game : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    public GameDifficulties GameDifficulty { get; private set; }
    private List<GameCategory> _gameCategories = new();
    public IEnumerable<GameCategory> GameCategories => _gameCategories.AsReadOnly();
    private List<GameTag> _gameTags = new();
    public IEnumerable<GameTag> GameTags => _gameTags.AsReadOnly();
    public GameGrid GameGrid { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Game() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Game(Guid id, string title, int height, int width, IEnumerable<HiddenWord> hiddenWords, GameDifficulties gameDifficulty, IEnumerable<GameCategory> gameCategories, IEnumerable<GameTag> gameTags) : this (title, height, width, hiddenWords, gameDifficulty, gameCategories, gameTags) {
        Id = id;
    }
    
    public Game(string title, int height, int width, IEnumerable<HiddenWord> hiddenWords, GameDifficulties gameDifficulty, IEnumerable<GameCategory> gameCategories, IEnumerable<GameTag> gameTags)
    {
        GameGrid = new GameGrid(height, width, hiddenWords);

        GameDifficulty = gameDifficulty;
        _gameCategories = gameCategories.ToList();
        _gameTags = gameTags.ToList();

        Title = title;
    }

    public void RecreateGrid(){
        GameGrid.RecreateGrid();
    }
}
