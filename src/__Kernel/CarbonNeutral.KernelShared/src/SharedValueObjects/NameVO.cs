namespace CarbonNeutral.KernelShared.SharedValueObjects;
[Owned]
public class NameVO : ValueObject
{
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public string NameSuffix { get; init; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private NameVO() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public NameVO(string firstName, string lastName, string middleName = "", string nameSuffix = "")
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        NameSuffix = nameSuffix;
    }
    
}
