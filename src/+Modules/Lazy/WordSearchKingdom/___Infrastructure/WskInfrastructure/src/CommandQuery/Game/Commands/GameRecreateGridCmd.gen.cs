// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameRecreateGridCmd : IRequest<Game>
{
    public Guid Id { get; set; }
    public Guid? KnownUserId { get; set; } = null;
    public GameRecreateGridCmd() { }
    public GameRecreateGridCmd(Guid id)
    {
        Id = id;
    }
}
