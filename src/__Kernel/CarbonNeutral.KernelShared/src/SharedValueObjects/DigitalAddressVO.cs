namespace CarbonNeutral.KernelShared.SharedValueObjects;
[Owned]
public class DigitalAddressVO : ValueObject
{
    public DigitalAddressType Type { get;  init; }
    public long PhoneNumber { get;  init; }
    public string Description { get;  init; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private DigitalAddressVO(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DigitalAddressVO(DigitalAddressType type, long phoneNumber, string description)
    {
        Type = type;
        PhoneNumber = phoneNumber;
        Description = description;
    }
}
