namespace CarbonNeutral.Common.Models;
public class MessageEntry
{
    public string Message { get; set; } = "";
    public DateTime Stamp { get; set; }
    public string UserName { get; set; } = "";
    public string Category { get; set; } = "";
    public string Topic { get; set; } = "";
}