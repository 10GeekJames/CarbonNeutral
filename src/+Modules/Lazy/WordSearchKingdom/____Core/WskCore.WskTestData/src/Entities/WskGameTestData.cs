namespace WskCore.WskTestData.Entities;
public static class WskGameTestData
{
    public static Game NormalEasyGame;       
    public static GameKey NormalEasyGameId = new(new Guid("1bd736d2-da2d-48c0-b19f-a0ec98396d49"));

    public static IEnumerable<Game> AllGames;

    static WskGameTestData()
    {
        var title = "My first awesome game!";
        var height = 25;
        var width = 25;
        var wordsToHide = new List<HiddenWord> { new("Sally"), new("Billy"), new("Larry"), new("Franky"), new("George") }.AsReadOnly();
        var gameDifficulty = GameDifficulties.Easy;
        var gameCategories = new List<GameCategory> { new("Shared"), new("Home"), new("School") }.AsReadOnly();
        var gameTags = new List<GameTag> { new("Fiction"), new("Adventure"), new("Action") }.AsReadOnly();
        
        NormalEasyGame = new (NormalEasyGameId, title, height, width, wordsToHide, gameDifficulty, gameCategories, gameTags);

        AllGames = new List<Game> {
            NormalEasyGame
        };
    }
}
