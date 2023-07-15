namespace CarbonNeutral.BlazorClient.UIUnitTests;

public class CounterComponentTests : BaseTest
{
    [Fact]
    public void CounterComponentTest()
    {
        var component = ctx.RenderComponent<Counter>();        

        // And the counter is initialized to 0
        component.Find("#currentCount").TextContent.Should().Be("0");

        // When I increment the count
        component.Find("#incrementPlus").Click();

        // The count should be 1
        component.Find("#currentCount").TextContent.Should().Be("1");

    }
}