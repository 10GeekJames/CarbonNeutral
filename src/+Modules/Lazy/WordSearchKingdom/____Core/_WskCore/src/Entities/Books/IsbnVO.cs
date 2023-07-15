namespace WskCore.Entities;

[Owned]
public class IsbnVO : ValueObject
{
    [IndexColumn("Index_Isbn", IsUnique=true)]
    public string Isbn { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private IsbnVO() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public IsbnVO(string isbn)
    {
        Isbn = isbn;
    }

    public override string ToString()
    {
        return Isbn;
    }
}
