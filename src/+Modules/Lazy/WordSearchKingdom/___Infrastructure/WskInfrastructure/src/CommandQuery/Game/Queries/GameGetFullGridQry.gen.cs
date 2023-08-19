// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameGetFullGridQry : IRequest<Game>
{
    public Guid Id { get; set; }
    public Guid KnownUserId { get; set; }
    public Guid GameGridInstanceId { get; set; }
    public GameGetFullGridQry() { }
    public GameGetFullGridQry(Guid gameId, Guid gameGridInstanceId)
    {
        GameGridInstanceId = gameGridInstanceId;
        Id = gameId;
    }
}
