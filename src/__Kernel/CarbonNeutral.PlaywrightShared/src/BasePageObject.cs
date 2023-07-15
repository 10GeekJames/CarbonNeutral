namespace CarbonNeutral.BlazorClient.UITests.PageObjects;
public class BasePageObject
{
    public virtual string PagePath {get;set;} = "";
    
    protected IBrowser Browser {get;}
    protected IPage Page {get;set;}
    protected string TestUrl {get;set;}
    
    private readonly string _basePath = "";
    
    public BasePageObject(IBrowser browser, string testUrl, string pagePath) {
        Browser = browser;  
        Page = Browser.NewPageAsync().GetAwaiter().GetResult();
        TestUrl = testUrl;
        PagePath = pagePath;
        _basePath = testUrl;
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