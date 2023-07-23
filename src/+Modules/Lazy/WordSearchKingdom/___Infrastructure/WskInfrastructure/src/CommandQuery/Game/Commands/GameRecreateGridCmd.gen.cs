// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameRecreateGridCmd : IRequest<Game>
{
    public Guid Id { get; set; }
    public GameRecreateGridCmd() { }
    public GameRecreateGridCmd(Guid id)
    {
        Id = id;
    }
}
