namespace YmiApplication.Shared.ViewModels;
public class DigitalAddressVOViewModel
{
    public DigitalAddressType Type { get; set; } = new();
    public string Value { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
