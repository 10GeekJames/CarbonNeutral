// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameGetByIdQry : IRequest<Game>
{
    public Guid Id { get; set; }
    public GameGetByIdQry() {}
    public GameGetByIdQry(Guid id)
    {
        Id = id;
    }
}
