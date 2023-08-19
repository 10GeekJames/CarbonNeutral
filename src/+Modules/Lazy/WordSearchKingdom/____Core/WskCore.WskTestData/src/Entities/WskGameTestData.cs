namespace WskCore.WskTestData.Entities;
public static class WskGameTestData
{
    public static Guid AnonymousUserId = new Guid("00000000-0000-0000-0000-000000000001");

    public static Game NormalEasyGame1;
    public static Guid NormalEasyGame1Id = new Guid("1bd736d2-da2d-48c0-b19f-a0ec98396d49");
    public static Guid NormalEasyGame1GridId = new Guid("2bd736d2-da2d-48c0-b19f-a0ec98396d49");
    public static Guid NormalEasyGame1GridInstanceId = new Guid("3bd736d2-da2d-48c0-b19f-a0ec98396d49");
    public static string NormalEasyGame1Title = "My first awesome game";
    public static int NormalEasyGame1Height = 25;
    public static int NormalEasyGame1Width = 25;
    public static Guid NormalEasyGame1KnownUserId = new Guid("7fe84750-58b7-49c0-81d5-0428c06633c5");
    public static GameDifficulties NormalEasyGame1Difficulty = GameDifficulties.Easy;
    public static IEnumerable<HiddenWord> NormalEasyGame1HiddenWords = new List<HiddenWord>() { new("Sally"), new("Billy"), new("Larry"), new("Franky"), new("George") }.AsReadOnly();
    public static IEnumerable<GameCategory> NormalEasyGame1Categories = new List<GameCategory>() { new("Shared"), new("Home"), new("School") }.AsReadOnly();
    public static IEnumerable<GameTag> NormalEasyGame1Tags = new List<GameTag>() { new("Fiction"), new("Adventure"), new("Action") };
    public static string NormalEasyGame1RowCellData = "[[\"J\",\"L\",\"P\",\"M\",\"O\",\"H\",\"A\",\"Q\",\"C\",\"E\",\"I\",\"S\",\"V\",\"T\",\"U\",\"Q\",\"G\",\"S\",\"K\",\"B\",\"B\",\"W\",\"P\",\"K\",\"Y\"],[\"D\",\"E\",\"D\",\"V\",\"L\",\"W\",\"T\",\"N\",\"C\",\"J\",\"P\",\"B\",\"R\",\"X\",\"K\",\"O\",\"Q\",\"Q\",\"U\",\"F\",\"O\",\"K\",\"K\",\"S\",\"Z\"],[\"I\",\"Y\",\"G\",\"B\",\"O\",\"F\",\"Q\",\"J\",\"J\",\"G\",\"A\",\"G\",\"N\",\"N\",\"R\",\"H\",\"X\",\"T\",\"C\",\"U\",\"G\",\"U\",\"T\",\"A\",\"I\"],[\"T\",\"B\",\"H\",\"Z\",\"Z\",\"U\",\"Z\",\"S\",\"T\",\"S\",\"D\",\"X\",\"I\",\"J\",\"N\",\"Y\",\"C\",\"B\",\"G\",\"M\",\"P\",\"V\",\"O\",\"J\",\"Y\"],[\"X\",\"N\",\"O\",\"U\",\"O\",\"K\",\"L\",\"X\",\"K\",\"F\",\"X\",\"N\",\"H\",\"H\",\"A\",\"R\",\"C\",\"J\",\"O\",\"A\",\"R\",\"D\",\"V\",\"G\",\"K\"],[\"Q\",\"J\",\"Z\",\"K\",\"C\",\"C\",\"J\",\"A\",\"K\",\"Y\",\"B\",\"H\",\"O\",\"G\",\"I\",\"H\",\"Q\",\"X\",\"E\",\"U\",\"T\",\"R\",\"W\",\"Q\",\"P\"],[\"T\",\"G\",\"M\",\"U\",\"G\",\"M\",\"M\",\"F\",\"E\",\"I\",\"P\",\"N\",\"R\",\"R\",\"U\",\"C\",\"O\",\"X\",\"D\",\"I\",\"B\",\"B\",\"A\",\"B\",\"R\"],[\"I\",\"Q\",\"B\",\"C\",\"U\",\"Y\",\"P\",\"K\",\"A\",\"X\",\"Q\",\"Z\",\"G\",\"Z\",\"H\",\"F\",\"Y\",\"J\",\"A\",\"C\",\"C\",\"G\",\"B\",\"G\",\"H\"],[\"Q\",\"C\",\"Q\",\"I\",\"E\",\"J\",\"G\",\"Q\",\"K\",\"F\",\"X\",\"V\",\"L\",\"Q\",\"M\",\"X\",\"P\",\"S\",\"Y\",\"X\",\"R\",\"J\",\"Q\",\"P\",\"A\"],[\"N\",\"B\",\"E\",\"G\",\"S\",\"J\",\"A\",\"J\",\"D\",\"B\",\"O\",\"F\",\"J\",\"P\",\"T\",\"Y\",\"Q\",\"I\",\"G\",\"T\",\"T\",\"E\",\"W\",\"D\",\"H\"],[\"X\",\"I\",\"F\",\"U\",\"I\",\"H\",\"A\",\"L\",\"Q\",\"I\",\"K\",\"P\",\"E\",\"C\",\"S\",\"G\",\"Z\",\"I\",\"Z\",\"G\",\"W\",\"V\",\"O\",\"C\",\"R\"],[\"K\",\"A\",\"U\",\"W\",\"C\",\"S\",\"O\",\"J\",\"A\",\"T\",\"R\",\"O\",\"C\",\"I\",\"D\",\"M\",\"V\",\"M\",\"T\",\"J\",\"M\",\"A\",\"K\",\"P\",\"D\"],[\"J\",\"A\",\"P\",\"A\",\"B\",\"Z\",\"S\",\"P\",\"C\",\"P\",\"T\",\"I\",\"V\",\"Z\",\"D\",\"Y\",\"C\",\"M\",\"M\",\"A\",\"K\",\"E\",\"H\",\"S\",\"J\"],[\"D\",\"I\",\"Y\",\"Z\",\"Q\",\"B\",\"U\",\"F\",\"L\",\"A\",\"E\",\"V\",\"E\",\"H\",\"S\",\"S\",\"I\",\"M\",\"H\",\"J\",\"S\",\"J\",\"N\",\"E\",\"W\"],[\"O\",\"M\",\"O\",\"C\",\"A\",\"P\",\"H\",\"H\",\"M\",\"L\",\"I\",\"N\",\"L\",\"I\",\"J\",\"O\",\"V\",\"L\",\"M\",\"A\",\"A\",\"J\",\"B\",\"N\",\"S\"],[\"A\",\"T\",\"F\",\"B\",\"O\",\"A\",\"C\",\"O\",\"P\",\"C\",\"B\",\"M\",\"O\",\"Z\",\"A\",\"B\",\"J\",\"I\",\"F\",\"M\",\"S\",\"E\",\"U\",\"G\",\"Z\"],[\"J\",\"R\",\"K\",\"Y\",\"F\",\"B\",\"T\",\"M\",\"G\",\"L\",\"W\",\"L\",\"L\",\"F\",\"T\",\"V\",\"A\",\"H\",\"M\",\"V\",\"T\",\"Q\",\"B\",\"D\",\"B\"],[\"H\",\"L\",\"D\",\"X\",\"V\",\"D\",\"Q\",\"M\",\"C\",\"X\",\"X\",\"C\",\"T\",\"S\",\"M\",\"M\",\"C\",\"Q\",\"C\",\"F\",\"M\",\"S\",\"X\",\"X\",\"N\"],[\"S\",\"Q\",\"O\",\"O\",\"S\",\"V\",\"Q\",\"U\",\"G\",\"H\",\"J\",\"H\",\"A\",\"L\",\"Z\",\"S\",\"E\",\"X\",\"A\",\"C\",\"N\",\"S\",\"O\",\"F\",\"Q\"],[\"X\",\"Q\",\"G\",\"Y\",\"N\",\"B\",\"C\",\"G\",\"U\",\"W\",\"V\",\"J\",\"T\",\"U\",\"L\",\"M\",\"M\",\"R\",\"W\",\"S\",\"V\",\"E\",\"Y\",\"H\",\"J\"],[\"W\",\"A\",\"O\",\"T\",\"A\",\"U\",\"X\",\"D\",\"E\",\"Y\",\"H\",\"F\",\"H\",\"W\",\"G\",\"F\",\"T\",\"Z\",\"S\",\"P\",\"L\",\"L\",\"M\",\"Q\",\"R\"],[\"F\",\"B\",\"W\",\"A\",\"T\",\"E\",\"R\",\"M\",\"E\",\"L\",\"L\",\"O\",\"N\",\"J\",\"A\",\"O\",\"B\",\"E\",\"P\",\"P\",\"E\",\"J\",\"C\",\"F\",\"Q\"],[\"A\",\"Y\",\"O\",\"O\",\"F\",\"P\",\"Y\",\"X\",\"Q\",\"T\",\"N\",\"X\",\"R\",\"P\",\"W\",\"H\",\"L\",\"W\",\"A\",\"U\",\"N\",\"C\",\"G\",\"J\",\"D\"],[\"I\",\"K\",\"F\",\"E\",\"U\",\"E\",\"V\",\"Y\",\"Q\",\"O\",\"V\",\"T\",\"R\",\"I\",\"V\",\"P\",\"K\",\"I\",\"T\",\"A\",\"K\",\"X\",\"M\",\"H\",\"I\"],[\"S\",\"C\",\"B\",\"B\",\"K\",\"P\",\"L\",\"Y\",\"H\",\"Z\",\"G\",\"M\",\"J\",\"O\",\"X\",\"Y\",\"N\",\"M\",\"Y\",\"T\",\"O\",\"Q\",\"X\",\"Z\",\"C\"]]";

    public static Game NormalEasyGame2;
    public static Guid NormalEasyGame2Id = new Guid("4bd736d2-da2d-48c0-b19f-a0ec98396d49");
    public static Guid NormalEasyGame2GridId = new Guid("5bd736d2-da2d-48c0-b19f-a0ec98396d49");
    public static Guid NormalEasyGame2GridInstanceId = new Guid("6bd736d2-da2d-48c0-b19f-a0ec98396d49");
    public static string NormalEasyGame2Title = "My second awesome game";
    public static int NormalEasyGame2Height = 25;
    public static int NormalEasyGame2Width = 25;
    public static GameDifficulties NormalEasyGame2Difficulty = GameDifficulties.Easy;
    public static IEnumerable<HiddenWord> NormalEasyGame2HiddenWords = new List<HiddenWord>() { new("Bishop"), new("Jalapeno"), new("Tomatoe"), new("Watermellon"), new("Tea") }.AsReadOnly();
    public static IEnumerable<GameCategory> NormalEasyGame2Categories = new List<GameCategory>() { new("Private") }.AsReadOnly();
    public static IEnumerable<GameTag> NormalEasyGame2Tags = new List<GameTag>() { new("Random") };

    public static IEnumerable<Game> AllGames;

    static WskGameTestData()
    {
        var gameDifficulty = GameDifficulties.Easy;

        NormalEasyGame1 = new(NormalEasyGame1Id, NormalEasyGame1KnownUserId, NormalEasyGame1Title, NormalEasyGame1Height, NormalEasyGame1Width, NormalEasyGame1Difficulty, NormalEasyGame1HiddenWords, NormalEasyGame1Categories, NormalEasyGame1Tags);
        var normalEasyGame1Grid = new GameGrid(NormalEasyGame2GridId, NormalEasyGame1, NormalEasyGame1KnownUserId, NormalEasyGame1RowCellData);
        normalEasyGame1Grid.AddGameGridInstance(NormalEasyGame1KnownUserId);
        NormalEasyGame1.AddGameGrid(normalEasyGame1Grid);

        NormalEasyGame2 = new(NormalEasyGame2Id, AnonymousUserId, NormalEasyGame2Title, NormalEasyGame2Height, NormalEasyGame2Width, NormalEasyGame2Difficulty, NormalEasyGame2HiddenWords, NormalEasyGame2Categories, NormalEasyGame2Tags);
        var normalEasyGame2Grid = new GameGrid(NormalEasyGame2, AnonymousUserId);
        normalEasyGame2Grid.AddGameGridInstance(AnonymousUserId);
        NormalEasyGame2.AddGameGrid(normalEasyGame2Grid);

        AllGames = new List<Game> {
            NormalEasyGame1,
            NormalEasyGame2
        };
    }
}
