namespace LiveRoomCore.Entities;
public class LiveRoomSessionsGetAllSpec : Specification<LiveRoomSession>
{
    public LiveRoomSessionsGetAllSpec(Guid knownUserId)
    {
        Query
            .Include(rs => rs.LiveRoomSessionGrid.HiddenWords)
            .Include(rs => rs.LiveRoomSessionTags)
            .Include(rs => rs.LiveRoomSessionCategories)
            .Where(rs=>rs.KnownUserId == knownUserId)
            .OrderBy(rs => rs.Title);
    }
}
