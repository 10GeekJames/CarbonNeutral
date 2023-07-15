namespace CarbonNeutral.Common.Models;
public class WindowDimension
{
    public int Width { get; set; }
    public int Height { get; set; }
    public string WidthPx => $"{Width}px";
    public string HeightPx => $"{Height}px";
}