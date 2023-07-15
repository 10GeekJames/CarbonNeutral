namespace CarbonNeutral.BlazorClient.UITests.Features;

[Binding]
public class CounterExperienceSteps : Steps
{
    private readonly CounterPage _counterPage;

    public CounterExperienceSteps(CounterPage counterPage)
    {
        _counterPage = counterPage;
    }

    [StepDefinition(@"we navigate to the counter page")]
    public async Task GivenWeNavigateToTheCounterPage()
    {
        await _counterPage.NavigateToAsync();
    }

    [StepDefinition(@"we click the increment button")]
    public async Task WeClickTheIncrementButton()
    {
        await _counterPage.IncrementValueAsync();
    }

    [StepDefinition(@"we are on the counter page")]
    public void WeAreOnTheCounterPage()
    {
        _counterPage.IsOnPage().Should().BeTrue();
    }
    
    [StepDefinition(@"the counter value is (.*)")]
    public async Task TheCounterValueIs(int counterValue)
    {
        (await _counterPage.GetIncrementValueAsync()).Should().Be(counterValue);
    }
    
    [StepDefinition(@"we wait (.*) seconds")]
    [StepDefinition(@"we wait (.*) second")]
    public void WeWaitXSeconds(float waitTime)
    {
        System.Threading.Thread.Sleep(Convert.ToInt32(waitTime * 1000f));        
    }    
}