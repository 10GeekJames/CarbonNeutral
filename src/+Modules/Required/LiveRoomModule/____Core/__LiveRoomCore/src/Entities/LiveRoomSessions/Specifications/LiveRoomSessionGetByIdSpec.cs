namespace LiveRoomCore.Entities;
public class LiveRoomSessionGetByIdSpec : Specification<LiveRoomSession>, ISingleResultSpecification<LiveRoomSession>
{
    public LiveRoomSessionGetByIdSpec(Guid id)
    {
        Query
            .Where(rs => rs.Id == id)
            .OrderBy(rs => rs.Title);
    }
}
