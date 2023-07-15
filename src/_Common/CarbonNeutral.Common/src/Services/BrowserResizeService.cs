
namespace CarbonNeutral.Common.Services;
public class BrowserResizeService
{
    private IJSRuntime JSRuntime;
    public BrowserResizeService(IJSRuntime jsRuntime){
        JSRuntime = jsRuntime;
    }
    
}