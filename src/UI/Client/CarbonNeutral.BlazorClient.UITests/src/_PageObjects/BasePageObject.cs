namespace CarbonNeutral.BlazorClient.UITests.PageObjects;
public class BasePageObject
{
    public virtual string PagePath {get;set;} = "";
    
    protected IBrowser Browser {get;}
    protected IPage Page {get;set;}
    protected AppConfig AppConfig {get;set;}

    private readonly string _basePath = "";
    
    public BasePageObject(IBrowser browser, AppConfig appConfig, string pagePath) {
        Browser = browser;  
        Page = Browser.NewPageAsync().GetAwaiter().GetResult();
        AppConfig = appConfig;
        PagePath = pagePath;
        _basePath = appConfig.TestUrl;
    }

    public async Task<string> GetTitle()
    {
        await Task.Yield();
        return await Page.TitleAsync();
    }

    protected async Task GotoAsync(string pagePath)
    {
        await Page.GotoAsync($"{_basePath}{pagePath}");
    }
}