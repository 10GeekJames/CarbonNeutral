namespace AccountModuleApi.FunctionalTests.ControllerTests;

[Collection("Sequential")]
public class KnownAccountControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    public KnownAccountControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    /* [Fact]
    public async Task ReturnsEmptyWhenNonLoggedInResponse()
    {
        var response = await _client.GetAsync(new KnownAccountGetByEmailRequest("10geekjames@gmail.com").BuildRouteFrom());
        response.EnsureSuccessStatusCode();

        var raw = await response.Content.ReadAsStringAsync();
        var result = await response
            .Content
            .ReadFromJsonAsync<KnownAccountViewModel>();

        //result.Should().HaveCount(AccountModuleTestData.KnownAccounts.Count());
        // Assert.Contains(result, i => i.Name == SeedBookData.TestBook1.Name);
    }    */

    [Fact]
    public async Task GetAllAsyncResponse()
    {
        var response = await _client.GetAsync(new KnownAccountGetAllRequest().BuildRouteFrom());
        response.EnsureSuccessStatusCode();

        var raw = await response.Content.ReadAsStringAsync();
        var result = await response
            .Content
            .ReadFromJsonAsync<List<KnownAccountViewModel>>();
        
        result.Any().Should().BeTrue();
        // Assert.Contains(result, i => i.Name == SeedBookData.TestBook1.Name);
    }   
}
