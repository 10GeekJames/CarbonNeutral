namespace LiveRoomCore.Entities;
public class LiveRoomSessionsGetAllSpec : Specification<LiveRoomSession>
{
    public LiveRoomSessionsGetAllSpec(Guid knownUserId)
    {
        Query
            .Where(rs=>rs.KnownUserId == knownUserId)
            .OrderBy(rs => rs.Title);
    }
}
