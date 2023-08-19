// ag=no
namespace WskInfrastructure.CommandQuery;
public partial class GameGetFullGridCmd : IRequest<Game>
{
    public Guid Id { get; set; }
    public Guid KnownUserId { get; set; }
    public Guid GameGridInstanceId { get; set; }
    public GameGetFullGridCmd() { }
    public GameGetFullGridCmd(Guid gameId, Guid gameGridInstanceId)
    {
        GameGridInstanceId = gameGridInstanceId;
        Id = gameId;
    }
}

