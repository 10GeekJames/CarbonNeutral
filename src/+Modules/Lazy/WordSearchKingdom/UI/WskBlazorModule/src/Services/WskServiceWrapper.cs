namespace WskBlazorModule;
public class WskServiceWrapper
{
    public IWskDataService? _wskService;
    public IWskDataService? IWskDataService { get => _wskService; set { _wskService = value; } }
}