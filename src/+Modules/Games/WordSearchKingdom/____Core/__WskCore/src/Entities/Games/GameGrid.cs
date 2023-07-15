namespace WskCore.Entities;

public class GameGrid : BaseEntityTracked<Guid>
{

    public int Height { get; private set; }
    public int Width { get; private set; }
    private List<HiddenWord> _hiddenWords = new();
    public IEnumerable<HiddenWord> HiddenWords => _hiddenWords.AsReadOnly();

    private List<RowCell> _rowCells = new();
    public IEnumerable<RowCell> RowCells => _rowCells.AsReadOnly();

    private Random _random = new Random();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private GameGrid() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public GameGrid(int height, int width, IEnumerable<HiddenWord> hiddenWords)
    {
        Height = height;
        Width = width;

        _hiddenWords = hiddenWords.ToList();
        _rowCells = setupGrid(height, width);

        hideTheWordsOnGrid(hiddenWords);
        fillEmptySpacesInTheGrid();        
    }

    public char[][] ToStringArray()
    {
        var stringArray = new char[Height][];
        for (var h = 0; h < Height; h++)
        {
            stringArray[h] = new char[Width];
            for (var w = 0; w < Width; w++)
            {
                stringArray[h][w] = _rowCells.Single(x => x.X == h && x.Y == w).Letter;
            }
        }
        return stringArray;
    }

    private void fillEmptySpacesInTheGrid()
    {
        for (var h = 0; h < Height; h++)
        {
            for (var w = 0; w < Width; w++)
            {
                var rowCell = _rowCells.Single(x => x.X == h && x.Y == w);
                if (rowCell.Letter == ' ')
                {
                    rowCell.SetLetter(getRandomLetter());
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

    private List<RowCell> setupGrid(int height, int width)
    {
        var rowCells = new List<RowCell>();

        for (var h = 0; h < height; h++)
        {
            for (var w = 0; w < width; w++)
            {
                rowCells.Add(new RowCell(h, w));
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
            var cell = _rowCells.Single(x => x.X == row && x.Y == col);

            if (cell.Letter != ' ' && cell.Letter != wordChars[i])
            {
                return false; // Letters don't match, cannot place the word here
            }

            cell.SetLetter(wordChars[i]);
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
}
