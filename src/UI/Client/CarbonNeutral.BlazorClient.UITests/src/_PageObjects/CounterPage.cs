namespace CarbonNeutral.BlazorClient.UITests.PageObjects;

public class CounterPage : BasePageObject {

    public readonly string CounterValueSelector = "#currentCount";
    public readonly string IncrementButtonSelector = "#incrementPlus";

    private IEnumerable<string> _properties;

    public CounterPage(IBrowser browser, AppConfig appConfig) : base(browser, appConfig, "/counter")
    {
        _properties = new List<string> {
            CounterValueSelector,
            IncrementButtonSelector
        };
    }

    public ILocator CounterValue => Page.Locator(CounterValueSelector);
    public ILocator IncrementButton => Page.Locator(IncrementButtonSelector);

    public async Task NavigateToAsync() => await base.GotoAsync(PagePath);
    public async Task IncrementValueAsync() => await IncrementButton.ClickAsync();
    public async Task<int> GetIncrementValueAsync() => int.Parse((await CounterValue.TextContentAsync()) ?? "-1"); 

    
    public bool IsOnPage() {
        var isOnPage = true;
       /*  foreach(var selector in _properties.Select(property => Page.Locator(property)))        
        {
            if(!(selector.IsVisibleAsync().GetAwaiter().GetResult()))
                isOnPage = false;
        } */
        return isOnPage;
    }
}