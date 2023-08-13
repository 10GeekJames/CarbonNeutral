// ag=yes
namespace LiveRoomInfrastructure.CommandQuery; 
public partial class LiveRoomSessionsGetAllQry : IRequest<List<LiveRoomSession>>
{
    public Guid? KnownUserId { get; set; } = null;
}
