namespace WskCore.Entities;
public class GameTag : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    private List<Game> _games = new();
    public IEnumerable<Game> Games => _games.AsReadOnly();
    
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private GameTag(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public GameTag(string title)
    {
        Title = title;
    }
}
