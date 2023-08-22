// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameCreateNewCmd : IRequest<Game>
{
    public string Title { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public GameDifficulties GameDifficulty { get; set; }
    public string WordsToHide { get; set; }
    public string GameCategories { get; set; }
    public string GameTags { get; set; }
        public Guid KnownUserId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public GameCreateNewCmd() { }
    public GameCreateNewCmd(string title, int height, int width, GameDifficulties gameDifficulty, string wordsToHide, string gameCategories, string gameTags)
    {
        Title = title;
        Height = height;
        Width = width;
        WordsToHide = wordsToHide;
        GameDifficulty = gameDifficulty;
        GameCategories = gameCategories;
        GameTags = gameTags;
    }
}
