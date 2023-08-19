namespace WskApplication.Shared.Requests;

public class GameCreateNewRequest : IRoutable
{
    protected readonly static string Route = "game/createnew";
    public string Title { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public GameDifficulties GameDifficulty { get; set; }
    public string WordsToHide { get; set; }
    public string GameCategories { get; set; }
    public string GameTags { get; set; }
    public Guid KnownUserId { get; set; }

    public GameCreateNewRequest() { }
    public GameCreateNewRequest(string title, int height, int width, GameDifficulties gameDifficulty, string wordsToHide, string gameCategories, string gameTags)
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
