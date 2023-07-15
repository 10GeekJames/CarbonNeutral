namespace WskCore.Entities;

public class RowCell : BaseEntityTracked<Guid>
{

    public string Pigment { get; private set; }
    public int X { get; init; }
    public int Y { get; init; }
    public char Letter { get; private set; }

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
}
