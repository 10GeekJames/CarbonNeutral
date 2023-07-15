namespace WskApi.FunctionalTests.ControllerTests;

[Collection("Sequential")]
public class GamesControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    public GamesControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnsAllGames()
    {
        var response = await _client.GetAsync(new GamesGetAllRequest().BuildRouteFrom());
        response.EnsureSuccessStatusCode();

        var raw = await response.Content.ReadAsStringAsync();
        var result = await response
            .Content
            .ReadFromJsonAsync<IEnumerable<GameViewModel>>();

        result.Should().HaveCount(GameWskTestData.AllGames.Count());
        // Assert.Contains(result, i => i.Name == SeedGameData.TestGame1.Name);
    }

    [Fact]
    public async Task ReturnsGameSearchResults()
    {
        var response = await _client.GetAsync(new GamesFindByTitleRequest("a").BuildRouteFrom());
        response.EnsureSuccessStatusCode();

        var raw = await response.Content.ReadAsStringAsync();
        var result = await response
            .Content
            .ReadFromJsonAsync<IEnumerable<GameViewModel>>();

        result.Should().HaveCountGreaterThan(0);
        // Assert.Contains(result, i => i.Name == SeedGameData.TestGame1.Name);
    }
}
