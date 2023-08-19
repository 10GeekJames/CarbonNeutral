// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameGetByIdQry : IRequest<Game>
{
    public Guid Id { get; set; }
    public Guid KnownUserId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public GameGetByIdQry() {}
    public GameGetByIdQry(Guid id)
    {
        Id = id;
    }
}
