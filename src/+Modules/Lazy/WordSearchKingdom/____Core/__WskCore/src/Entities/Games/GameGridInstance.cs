namespace WskCore.Entities;

public class GameGridInstance : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string? Title { get; private set; }
    public GameGrid GameGrid { get; private set; }
    public Guid KnownUserId { get; private set; }
    
    [NotMapped, JsonIgnore]
    public List<Point>? CompletedWords => !string.IsNullOrWhiteSpace(CompletedWordCellData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<List<Point>?>(CompletedWordCellData) : null;
    public string CompletedWordCellData { get; private set; } = "";
    
    [NotMapped, JsonIgnore]
    public IEnumerable<string>? CompletedWordsDataArray => !string.IsNullOrWhiteSpace(CompletedWordsData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>?>(CompletedWordsData) : null;
    public string CompletedWordsData { get; private set; } = "";

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private GameGridInstance() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public GameGridInstance(GameGrid gameGrid, Guid knownUserId)
    {
        GameGrid = gameGrid;
        KnownUserId = knownUserId;
    }

    public GameGridInstance(Guid gameGridInstanceId, GameGrid gameGrid, Guid knownUserId) : this(gameGrid, knownUserId)
    {
        Id = gameGridInstanceId;
    }

    private void ClearAnswers()
    {
        CompletedWordCellData = "[]";
    }

    public void AddColoredCell(int x, int y)
    {
        var selectedCellsPointList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Point>?>(CompletedWordCellData);
        if (selectedCellsPointList == null)
        {
            selectedCellsPointList = new();
        }
        if (!selectedCellsPointList.Contains(new(x, y)))
        {
            selectedCellsPointList.Add(new(x, y));
        }

        CompletedWordCellData = Newtonsoft.Json.JsonConvert.SerializeObject(selectedCellsPointList);
    }
    
   
}
