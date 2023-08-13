namespace LiveRoomApi.FunctionalTests.ControllerTests;

[Collection("Sequential")]
public class LiveRoomSessionsControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    public LiveRoomSessionsControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnsAllLiveRoomSessions()
    {
        var response = await _client.GetAsync(new LiveRoomSessionsGetAllRequest().BuildRouteFrom());
        response.EnsureSuccessStatusCode();

        var raw = await response.Content.ReadAsStringAsync();
        var result = await response
            .Content
            .ReadFromJsonAsync<IEnumerable<LiveRoomSessionViewModel>>();

        result.Should().HaveCount(LiveRoomSessionLiveRoomTestData.AllLiveRoomSessions.Count());
        // Assert.Contains(result, i => i.Name == SeedLiveRoomSessionData.TestLiveRoomSession1.Name);
    }

    [Fact]
    public async Task ReturnsLiveRoomSessionSearchResults()
    {
        var response = await _client.GetAsync(new LiveRoomSessionsFindByTitleRequest("a").BuildRouteFrom());
        response.EnsureSuccessStatusCode();

        var raw = await response.Content.ReadAsStringAsync();
        var result = await response
            .Content
            .ReadFromJsonAsync<IEnumerable<LiveRoomSessionViewModel>>();

        result.Should().HaveCountGreaterThan(0);
        // Assert.Contains(result, i => i.Name == SeedLiveRoomSessionData.TestLiveRoomSession1.Name);
    }
}
