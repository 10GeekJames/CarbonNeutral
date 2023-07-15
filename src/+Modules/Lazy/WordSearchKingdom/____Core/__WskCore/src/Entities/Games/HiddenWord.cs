namespace WskCore.Entities;

public class HiddenWord : BaseEntityTracked<Guid>
{
    public string Word { get; private set; }
        
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private HiddenWord() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public HiddenWord(string word)
    {
        Word = word;
    }
}
