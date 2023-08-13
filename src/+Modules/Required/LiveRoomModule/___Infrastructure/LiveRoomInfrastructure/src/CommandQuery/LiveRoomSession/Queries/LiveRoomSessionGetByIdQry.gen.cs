// ag=yes
namespace LiveRoomInfrastructure.CommandQuery; 
public partial class LiveRoomSessionGetByIdQry : IRequest<LiveRoomSession>
{
    public Guid Id { get; set; }
    public LiveRoomSessionGetByIdQry() {}
    public LiveRoomSessionGetByIdQry(Guid id)
    {
        Id = id;
    }
}
