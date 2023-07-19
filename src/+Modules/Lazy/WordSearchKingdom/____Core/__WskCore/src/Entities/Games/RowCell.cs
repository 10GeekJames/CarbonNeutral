namespace WskCore.Entities;

public class RowCell : BaseEntityTracked<Guid>
{

    public string Pigment { get; private set; }
    public int X { get; init; }
    public int Y { get; init; }
    public char Letter { get; private set; }

    public bool IsStartHighlight { get; private set; } = false;
    public bool IsEndHighlight { get; private set; } = false;
    public bool IsCompletedSet { get; private set; } = false;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private RowCell() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public RowCell(int x, int y, string pigment = "", char letter = ' ')
    {
        Pigment = pigment;
        X = x;
        Y = y;
        Letter = letter;
    }
    public void SetLetter(char letter)
    {
        Letter = letter;
    }

    public void SetPigment(string pigment)
    {
        Pigment = pigment;
    }

    public void SetStartHighlight(bool isStartHighlight = true)
    {
        IsStartHighlight = isStartHighlight;
        IsEndHighlight = false;
    }
    public void SetEndHighlight(bool isEndHighlight = true)
    {
        IsEndHighlight = isEndHighlight;
        IsStartHighlight = false;
    }

    public void ClearHighlights()
    {
        IsStartHighlight = false;
        IsEndHighlight = false;
    }

    public void CompleteSet() => IsCompletedSet = true;

}
