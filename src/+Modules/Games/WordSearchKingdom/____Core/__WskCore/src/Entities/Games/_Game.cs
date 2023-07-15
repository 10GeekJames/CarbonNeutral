namespace WskCore.Entities;

public class Game : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    public GameDifficulties GameDifficulty { get; private set; }
    public IEnumerable<GameCategory> GameCategories { get; private set; }
    public IEnumerable<GameTag> GameTags { get; private set; }
    public GameGrid GameGrid { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Game() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Game(Guid id, int height, int width, IEnumerable<HiddenWord> hiddenWords, GameDifficulties gameDifficulty, IEnumerable<GameCategory> gameCategories, IEnumerable<GameTag> gameTags) : this (height, width, hiddenWords, gameDifficulty, gameCategories, gameTags) {
        Id = id;
    }
    
    public Game(int height, int width, IEnumerable<HiddenWord> hiddenWords, GameDifficulties gameDifficulty, IEnumerable<GameCategory> gameCategories, IEnumerable<GameTag> gameTags)
    {
        GameGrid = new GameGrid(height, width, hiddenWords);

        GameDifficulty = gameDifficulty;
        GameCategories = gameCategories;
        GameTags = gameTags;

        Title = "My awesome game!";
    }
}
