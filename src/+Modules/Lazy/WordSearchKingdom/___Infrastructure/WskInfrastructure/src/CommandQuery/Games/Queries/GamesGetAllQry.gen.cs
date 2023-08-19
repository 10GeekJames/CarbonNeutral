// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GamesGetAllQry : IRequest<List<Game>>
{
    public Guid KnownUserId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public bool UserOnly { get; set; } = true;
}
