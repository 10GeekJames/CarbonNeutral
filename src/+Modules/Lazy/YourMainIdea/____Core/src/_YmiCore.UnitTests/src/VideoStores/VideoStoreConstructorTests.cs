namespace YmiCore.UnitTests;
public class VideoStoreConstructorTests
{
    [Fact]
    public void ICanCreateAVideoStoreWithInventory()
    {
        // Given I have a video store name "My Video Store 1"
        var storeName = "My Video Store 1";
        // And I have videos "Hijack", "Lojack"
        var videos = new List<Video> { new("Hijack"), new("Lojack") };
        // When I create the video store
        var videoStore = new VideoStore(storeName, videos);
        // Then I have a video store
        videoStore.Should().NotBeNull();
        // And it has the correct data
        videoStore.Name.Should().Be(storeName);
        // And it has 2 videos in inventory    
        videoStore.Videos.Count().Should().Be(2);
    }
}
