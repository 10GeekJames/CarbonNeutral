namespace WskApplication.Shared.Requests;

public class GameCreateNewRequest : IRoutable
{
    protected readonly static string Route = "game/createnew";
    public string Title { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public List<HiddenWordViewModel> WordsToHide { get; set; }
    public GameDifficulties GameDifficulty { get; set; }
    public List<GameCategoryViewModel> GameCategories { get; set; }
    public List<GameTagViewModel> GameTags { get; set; }
    public Guid KnownUserId { get; set; }

    public GameCreateNewRequest() { }
    public GameCreateNewRequest(string title, int height, int width, List<HiddenWordViewModel> wordsToHide, GameDifficulties gameDifficulty, List<GameCategoryViewModel> gameCategories, List<GameTagViewModel> gameTags)
    {
        Title = title;
        Height = height;
        Width = width;
        WordsToHide = wordsToHide;
        GameDifficulty = gameDifficulty;
        GameCategories = gameCategories;
        GameTags = gameTags;
    }
    public string BuildRouteFrom() => GameCreateNewRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
