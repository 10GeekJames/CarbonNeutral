namespace CarbonNeutral.Common.Models
{
    public class MudSelectItemModel
    {
        public string Value { get; set; } = string.Empty;
        public string AdornmentIcon { get; set; } = string.Empty;
        public string Style { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public bool IsSelected { get; set; } = false;
        public string ValidPrefix { get; set; } = string.Empty;
    }
}