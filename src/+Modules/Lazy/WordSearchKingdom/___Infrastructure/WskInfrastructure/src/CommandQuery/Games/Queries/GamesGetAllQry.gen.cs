// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GamesGetAllQry : IRequest<List<Game>>
{
    public Guid? KnownUserId { get; set; } = null;
    public bool UserOnly { get; set; } = true;
}
