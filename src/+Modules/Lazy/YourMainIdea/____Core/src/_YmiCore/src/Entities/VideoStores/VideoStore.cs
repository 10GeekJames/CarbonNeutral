namespace YmiCore.Entities;
public class VideoStore
{
    public string Name { get; private set; }

    private List<Video> _videos = new();
    public IEnumerable<Video> Videos => _videos.AsReadOnly();

    public VideoStore(string name, IEnumerable<Video> videos)
    {
        Name = name;
        AddVideos(videos);
    }
    private void AddVideos(IEnumerable<Video> videos)
    {
        foreach(var video in videos) {
            AddVideo(video);
        }
    }
    private void AddVideo(Video video) {
        if(!_videos.Any(rs=>rs.Name == video.Name)) {
            _videos.Add(video);
        }
    }
}
