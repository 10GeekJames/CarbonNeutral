using System.Data.Common;
using System.Threading.Tasks.Dataflow;
namespace WskCore.Entities;
public class GameGrid : BaseEntityTracked<Guid>
{
    public Game Game { get; private set; }
    public Guid? KnownUserId { get; init; }

    private List<GameGridInstance> _gameGridInstances = new();
    public IEnumerable<GameGridInstance> GameGridInstances => _gameGridInstances.AsReadOnly();
    public bool IsCurrent { get; private set; } = true;

    public string RowCellData { get; private set; } = "";


    [NotMapped, JsonIgnore]
    public char[,]? RowCellDataArray => !string.IsNullOrWhiteSpace(RowCellData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<char[,]>(RowCellData) : null;

    Random _random = new Random();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private GameGrid() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public GameGrid(Guid gameGridId, Game game, string rowCellData = "", Guid? knownUserId = null) : this(game, rowCellData, knownUserId)
    {
        Id = gameGridId;
    }

    public GameGrid(Game game, string rowCellData = "", Guid? knownUserId = null)
    {
        Game = game;
        KnownUserId = knownUserId;
        if (rowCellData.Length > 50)
        {
            RowCellData = rowCellData;
        }
        else
        {
            RecreateGrid();
        }
    }
    public void RecreateGrid() //DoNotPropigate
    {
        // find longest word in hidden words
        var longestWord = Game.HiddenWords.OrderByDescending(word => word.Word.Length).First();
        // find hidden words total count
        var hiddenWordsCount = Game.HiddenWords.Count();
        // if longest word is greater than height and Game.Width then throw exception
        if (longestWord.Word.Length > Game.Height && longestWord.Word.Length > Game.Width)
        {
            throw new InvalidOperationException("The longest word is too long to fit on the grid.");
        }

        ClearGrid();

        RowCellData = ConvertRowCellArrayToString(SetupGrid(Game.Height, Game.Width));
        HideTheWordsOnGrid(Game.HiddenWords);
        FillEmptySpacesInTheGrid();
        Game.HiddenWords.ToList().ForEach(word => word.ResetFound());
    }

    public void SetIsCurrent(bool isCurrent = true)
    {
        if (isCurrent == true)
        {
            Game.GameGrids.ToList().ForEach(grid => grid.SetIsCurrent(false));
            IsCurrent = true;
        }

        IsCurrent = isCurrent;
    }

    public void AddGameGridInstance(GameGridInstance gameGridInstance)
    {
        if (!gameGridInstance.KnownUserId.HasValue && KnownUserId.HasValue)
        {
            gameGridInstance = new(this, KnownUserId);

        }
        _gameGridInstances.Add(gameGridInstance);
    }

    private void ClearGrid()
    {
        RowCellData = ConvertRowCellArrayToString(SetupGrid(Game.Height, Game.Width));
    }
    private void FillEmptySpacesInTheGrid()
    {
        var rowCells = ConvertRowCellStringToArray(RowCellData);

        for (var y = 0; y < Game.Height; y++)
        {
            for (var x = 0; x < Game.Width; x++)
            {
                var rowCell = rowCells[x, y];
                if (rowCell == ' ')
                {
                    rowCells[x, y] = GetRandomLetter();
                }
            }
        }

        RowCellData = ConvertRowCellArrayToString(rowCells);
    }
    private char GetRandomLetter()
    {
        var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var index = _random.Next(0, letters.Length);
        return letters[index];
    }
    private char[,] SetupGrid(int height, int width)
    {
        char[,] rowCells = new char[height, Game.Width];
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < Game.Width; x++)
            {
                rowCells[x, y] = ' ';
            }
        }
        return rowCells;
    }
    // place words where the fit in various places on the grid to create a word search
    // overlap them where the letters are shared and they fit
    // don't overlap where letters don't match
    // go up down backwards
    private void HideTheWordsOnGrid(IEnumerable<HiddenWord> wordsToHide)
    {
        foreach (var hiddenWord in wordsToHide)
        {
            bool placed = false;
            var wordLength = hiddenWord.Word.Length;
            var circutBreakerAfter = 100;
            var circutBreaker = 0;
            while (!placed && circutBreaker++ < circutBreakerAfter)
            {
                var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
                Shuffle(directions); // Randomize the order of directions
                var directionIndex = _random.Next(0, directions.Count);
                var direction = directions[directionIndex];
                var (startRow, startCol) = GetRandomStartPoint(wordLength, direction);
                if (TryPlaceWord(hiddenWord, startRow, startCol, direction))
                {
                    placed = true;
                    break;
                }
            }
            if (!placed)
            {
                throw new InvalidOperationException("Failed to place the hidden word on the grid.");
            }
        }
    }
    private bool TryPlaceWord(HiddenWord hiddenWord, int startRow, int startCol, Direction direction)
    {
        var wordLength = hiddenWord.Word.Length;
        var wordChars = hiddenWord.Word.ToUpper().ToCharArray();
        int rowIncrement = 0;
        int colIncrement = 0;
        var rowCellAsArray = ConvertRowCellStringToArray(RowCellData);
        switch (direction)
        {
            case Direction.Horizontal:
                colIncrement = 1;
                break;
            case Direction.Vertical:
                rowIncrement = 1;
                break;
            case Direction.DiagonalUp:
                rowIncrement = -1;
                colIncrement = 1;
                break;
            case Direction.DiagonalDown:
                rowIncrement = 1;
                colIncrement = 1;
                break;
        }
        if (startRow + rowIncrement * (wordLength - 1) >= Game.Height ||
            startCol + colIncrement * (wordLength - 1) >= Game.Width)
        {
            return false; // The word doesn't fit within the grid in this direction
        }
        for (int i = 0; i < wordLength; i++)
        {
            var row = startRow + rowIncrement * i;
            var col = startCol + colIncrement * i;
            var cell = rowCellAsArray[row, col];
            if (cell != ' ' && cell != wordChars[i])
            {
                return false; // Letters don't match, cannot place the word here
            }
            rowCellAsArray[row, col] = wordChars[i];
        }
        RowCellData = ConvertRowCellArrayToString(rowCellAsArray);
        return true; // Successfully placed the word on the grid
    }
    private void Shuffle<T>(List<T> list)
    {
        var random = new Random();
        for (int i = 0; i < list.Count - 1; i++)
        {
            int j = _random.Next(i, list.Count);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
    private (int, int) GetRandomStartPoint(int wordLength, Direction direction)
    {
        int startRow, startCol;
        switch (direction)
        {
            case Direction.Horizontal:
                startRow = _random.Next(0, Game.Height);
                startCol = _random.Next(0, Game.Width - wordLength + 1);
                break;
            case Direction.Vertical:
                startRow = _random.Next(0, Game.Height - wordLength + 1);
                startCol = _random.Next(0, Game.Width);
                break;
            case Direction.DiagonalUp:
                startRow = _random.Next(wordLength - 1, Game.Height);
                startCol = _random.Next(0, Game.Width - wordLength + 1);
                break;
            case Direction.DiagonalDown:
                startRow = _random.Next(0, Game.Height - wordLength + 1);
                startCol = _random.Next(0, Game.Width - wordLength + 1);
                break;
            default:
                startRow = 0;
                startCol = 0;
                break;
        }
        return (startRow, startCol);
    }

    private string ConvertRowCellArrayToString(char[,] rowCells)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(rowCells);
    }
    private char[,] ConvertRowCellStringToArray(string rowCellString)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<char[,]>(rowCellString);
    }
}
