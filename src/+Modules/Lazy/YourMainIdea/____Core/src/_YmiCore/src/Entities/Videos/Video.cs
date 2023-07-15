namespace YmiCore.Entities;
public class Video
{
    public string Name { get; private set; }

    public Video(string name)
    {
        Name = name;
    }
}
