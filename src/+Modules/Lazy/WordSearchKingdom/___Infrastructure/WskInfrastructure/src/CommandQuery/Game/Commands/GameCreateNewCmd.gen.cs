// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameCreateNewCmd : IRequest<Game>
{
    public string Title { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public List<HiddenWord> WordsToHide { get; set; }
    public GameDifficulties GameDifficulty { get; set; }
    public List<GameCategory> GameCategories { get; set; }
    public List<GameTag> GameTags { get; set; }
    public GameCreateNewCmd() { }
    public GameCreateNewCmd(string title, int height, int width, List<HiddenWord> wordsToHide, GameDifficulties gameDifficulty, List<GameCategory> gameCategories, List<GameTag> gameTags)
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
