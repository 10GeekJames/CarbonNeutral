namespace WskCore.Entities;

public class Game : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    public Guid KnownUserId { get; private set; }
    public int Height { get; private set; } = 0;
    public int Width { get; private set; } = 0;

    public GameDifficulties GameDifficulty { get; private set; }

    private List<GameCategory> _gameCategories = new();
    public IEnumerable<GameCategory> GameCategories => _gameCategories.AsReadOnly();

    private List<GameTag> _gameTags = new();
    public IEnumerable<GameTag> GameTags => _gameTags.AsReadOnly();

    private List<GameGrid> _gameGrids = new();
    public IEnumerable<GameGrid> GameGrids => _gameGrids.AsReadOnly();

    public GameGrid? GameGrid => GameGrids.FirstOrDefault();

    private List<HiddenWord> _hiddenWords = new();
    public IEnumerable<HiddenWord> HiddenWords => _hiddenWords.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Game() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Game(Guid id, Guid knownUserId, string title, int height, int width, GameDifficulties gameDifficulty, IEnumerable<HiddenWord> hiddenWords, IEnumerable<GameCategory> gameCategories, IEnumerable<GameTag> gameTags) : this(knownUserId, title, height, width, gameDifficulty, hiddenWords, gameCategories, gameTags)
    {
        Id = id;
    }

    public Game(Guid knownUserId, string title, int height, int width, GameDifficulties gameDifficulty, IEnumerable<HiddenWord> hiddenWords, IEnumerable<GameCategory> gameCategories, IEnumerable<GameTag> gameTags)
    {
        Title = title;
        KnownUserId = knownUserId;
        Height = height;
        Width = width;
        GameDifficulty = gameDifficulty;

        _hiddenWords = hiddenWords.ToList();
        _gameCategories = gameCategories.ToList();
        _gameTags = gameTags.ToList();
    }

    public void CreateNewGridVersion(Guid knownUserId)
    {
        var newGameGrid = new GameGrid(this, knownUserId, string.Empty);
        _gameGrids.Add(newGameGrid);
    }
    
    public void AddGameGrid(GameGrid gameGrid)
    {
        if(!_gameGrids.Any(rs=>rs.Id == gameGrid.Id))
            _gameGrids.Add(gameGrid);            
    }
}
