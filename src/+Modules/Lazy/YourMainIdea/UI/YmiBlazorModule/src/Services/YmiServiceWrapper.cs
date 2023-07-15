namespace YmiBlazorModule;
public class YmiServiceWrapper
{
    public IYmiDataService? _ymiService;
    public IYmiDataService? IYmiDataService { get => _ymiService; set { _ymiService = value; } }
}