namespace WskCore.Entities;

public class Game : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    public Guid KnownUserId { get; private set; }
    public int Height { get; private set; } = 0;
    public int Width { get; private set; } = 0;

    public GameDifficulties GameDifficulty { get; private set; }

    public GameGrid? GameGrid => GameGrids.FirstOrDefault(); //Propigate
    
    private List<GameGrid> _gameGrids = new();
    public IEnumerable<GameGrid> GameGrids => _gameGrids.AsReadOnly();
    
    
    [NotMapped, JsonIgnore]
    public IEnumerable<string>? HiddenWords => !string.IsNullOrWhiteSpace(HiddenWordsData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>?>(HiddenWordsData) : null;  //Propigate
    public string HiddenWordsData { get; private set; } = "";
        
    [NotMapped, JsonIgnore]
    public IEnumerable<string>? GameTags => !string.IsNullOrWhiteSpace(GameTagsData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>?>(GameTagsData) : null; //Propigate
    public string GameTagsData { get; private set; } = "";

    
    [NotMapped, JsonIgnore]
    public IEnumerable<string>? GameCategories => !string.IsNullOrWhiteSpace(GameCategoriesData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>?>(GameCategoriesData) : null; //Propigate
    public string GameCategoriesData { get; private set; } = "";


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Game() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Game(Guid id, Guid knownUserId, string title, int height, int width, GameDifficulties gameDifficulty, string hiddenWords, string gameCategories, string gameTags) : this(knownUserId, title, height, width, gameDifficulty, hiddenWords, gameCategories, gameTags)
    {
        Id = id;
    }

    public Game(Guid knownUserId, string title, int height, int width, GameDifficulties gameDifficulty, string hiddenWords, string gameCategories, string gameTags)
    {
        Title = title;
        KnownUserId = knownUserId;
        Height = height;
        Width = width;
        GameDifficulty = gameDifficulty;
        HiddenWordsData = hiddenWords;
        GameCategoriesData = gameCategories;
        GameTagsData = gameTags;
        // CreateNewGridVersion(knownUserId);
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
