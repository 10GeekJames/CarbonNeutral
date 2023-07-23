namespace WskCore.Entities;
public class GameGrid : BaseEntityTracked<Guid>
{
    public int Height { get; private set; } = 0;
    public int Width { get; private set; } = 0;
    private List<HiddenWord> _hiddenWords = new();
    public IEnumerable<HiddenWord> HiddenWords => _hiddenWords.AsReadOnly();

    [NotMapped]
    public char[,]? RowCellsData { get; set; } //Propigate

    public string RowCellDataAsString //Propigate
    {
        get { return RowCellsData != null ? JsonConvert.SerializeObject(RowCellsData) : null; }
        set { RowCellsData = !string.IsNullOrWhiteSpace(value) ? JsonConvert.DeserializeObject<char[,]>(value) : null; }
    }

    [NotMapped]
    public List<(int x, int y)>? CompletedWordCells { get; set; } //Propigate
    public string? CompletedWordCellsAsString //Propigate
    {
        get { return CompletedWordCells != null ? JsonConvert.SerializeObject(CompletedWordCells) : null; }
        set { CompletedWordCells = !string.IsNullOrWhiteSpace(value) ? JsonConvert.DeserializeObject<List<(int x, int y)>>(value) : new(); }
    }
    private Random _random = new Random();
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private GameGrid() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public GameGrid(int height, int width, IEnumerable<HiddenWord> hiddenWords)
    {
        Height = height;
        Width = width;
        _hiddenWords = hiddenWords.ToList();
        RowCellsData = setupGrid(height, width);
        //_rowCells = setupGrid(height, width);
        hideTheWordsOnGrid(hiddenWords);
        fillEmptySpacesInTheGrid();
    }
    public void RecreateGrid()
    {
        clearGrid();
        RowCellsData = setupGrid(Height, Width);
        hideTheWordsOnGrid(HiddenWords);
        fillEmptySpacesInTheGrid();
        _hiddenWords.ForEach(word => word.ResetFound());
    }
    private void clearGrid()
    {
        RowCellsData = setupGrid(Height, Width);
    }
    private void fillEmptySpacesInTheGrid()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var rowCell = RowCellsData[x, y];
                if (rowCell == ' ')
                {
                    rowCell = getRandomLetter();
                }
            }
        }
    }
    private char getRandomLetter()
    {
        var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var index = _random.Next(0, letters.Length);
        return letters[index];
    }
    private char[,] setupGrid(int height, int width)
    {
        char[,] rowCells = new char[height, width];
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
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
    private void hideTheWordsOnGrid(IEnumerable<HiddenWord> wordsToHide)
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
                shuffle(directions); // Randomize the order of directions
                var directionIndex = _random.Next(0, directions.Count);
                var direction = directions[directionIndex];
                var (startRow, startCol) = getRandomStartPoint(wordLength, direction);
                if (tryPlaceWord(hiddenWord, startRow, startCol, direction))
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
    private bool tryPlaceWord(HiddenWord hiddenWord, int startRow, int startCol, Direction direction)
    {
        var wordLength = hiddenWord.Word.Length;
        var wordChars = hiddenWord.Word.ToUpper().ToCharArray();
        int rowIncrement = 0;
        int colIncrement = 0;
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
        if (startRow + rowIncrement * (wordLength - 1) >= Height ||
            startCol + colIncrement * (wordLength - 1) >= Width)
        {
            return false; // The word doesn't fit within the grid in this direction
        }
        for (int i = 0; i < wordLength; i++)
        {
            var row = startRow + rowIncrement * i;
            var col = startCol + colIncrement * i;
            var cell = RowCellsData[row, col];
            if (cell != ' ' && cell != wordChars[i])
            {
                return false; // Letters don't match, cannot place the word here
            }
            RowCellsData[row, col] = wordChars[i];
        }
        return true; // Successfully placed the word on the grid
    }
    private void shuffle<T>(List<T> list)
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
    private (int, int) getRandomStartPoint(int wordLength, Direction direction)
    {
        int startRow, startCol;
        switch (direction)
        {
            case Direction.Horizontal:
                startRow = _random.Next(0, Height);
                startCol = _random.Next(0, Width - wordLength + 1);
                break;
            case Direction.Vertical:
                startRow = _random.Next(0, Height - wordLength + 1);
                startCol = _random.Next(0, Width);
                break;
            case Direction.DiagonalUp:
                startRow = _random.Next(wordLength - 1, Height);
                startCol = _random.Next(0, Width - wordLength + 1);
                break;
            case Direction.DiagonalDown:
                startRow = _random.Next(0, Height - wordLength + 1);
                startCol = _random.Next(0, Width - wordLength + 1);
                break;
            default:
                startRow = 0;
                startCol = 0;
                break;
        }
        return (startRow, startCol);
    }
    public void UpdateCharacterAtPosition(int x, int y, char newChar)
    {
        if (RowCellsData == null)
        {
            throw new InvalidOperationException("RowCellData has not been initialized.");
        }
        if (x < 0 || x >= RowCellsData.GetLength(0) || y < 0 || y >= RowCellsData.GetLength(1))
        {
            throw new ArgumentOutOfRangeException("Position is out of range.");
        }
        RowCellsData[x, y] = newChar;
    }
    public void AddColoredCell(int x, int y)
    {
        if (RowCellsData == null)
        {
            throw new InvalidOperationException("RowCellData has not been initialized.");
        }
        if (x < 0 || x >= RowCellsData.GetLength(0) || y < 0 || y >= RowCellsData.GetLength(1))
        {
            throw new ArgumentOutOfRangeException("Position is out of range.");
        }
        if (CompletedWordCells == null)
        {
            CompletedWordCells = new List<(int x, int y)>();
        }
        CompletedWordCells.Add((x, y));
    }
}
