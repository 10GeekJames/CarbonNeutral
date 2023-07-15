namespace CarbonNeutral.Common;
public class MenuItem
{
    public long Level { get; set; } = 0;
    public string Text { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string UrlAutomaped { get; set; } = string.Empty;
    public string Parent { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public bool IsSeparator { get; set; } = false;
    public List<MenuItem> Items = new();
}