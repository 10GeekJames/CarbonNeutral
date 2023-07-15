using System.Reflection;

namespace AddToMeeting.UITests.Hooks;

[Binding]
public class SpecFlowBindingHooks
{
    private readonly IObjectContainer objectContainer;
    
    public SpecFlowBindingHooks(IObjectContainer objectContainer)
    {
        this.objectContainer = objectContainer;
    }

    [BeforeScenario]
    public async Task SetupWebDriver()
    {
        var builder = new ConfigurationBuilder();

            builder
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? "");
        
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                            
        var defaultConfig = builder.Build();
        var appConfig = defaultConfig.Get<AppConfig>();
        
        this.objectContainer.RegisterInstanceAs<AppConfig>(appConfig!);   

        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {
            Headless=false,
            SlowMo=50,
            Devtools=true,
            Timeout=0,
            Args = new[] { "--start-maximized" }
        });
        
        this.objectContainer.RegisterInstanceAs<IPlaywright>(playwright);
        this.objectContainer.RegisterInstanceAs<IBrowser>(browser);
        var counterPage = new CounterPage(browser, appConfig!);
        this.objectContainer.RegisterInstanceAs<CounterPage>(counterPage);   
    }

    [AfterScenario]
    public async Task CleanupWebDriver()
    {
        var browser = this.objectContainer.Resolve<IBrowser>();
        await browser.CloseAsync();
        var playwright = this.objectContainer.Resolve<IPlaywright>();
        playwright.Dispose();
    }
}
