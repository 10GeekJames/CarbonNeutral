namespace LiveRoomCore.Entities;
public class LiveRoomSessionGetByIdSpec : Specification<LiveRoomSession>, ISingleResultSpecification<LiveRoomSession>
{
    public LiveRoomSessionGetByIdSpec(Guid id)
    {
        Query
            .Include(rs=>rs.LiveRoomSessionGrid)
                .ThenInclude(rs => rs.HiddenWords)
            .Include(rs => rs.LiveRoomSessionTags)
            .Include(rs => rs.LiveRoomSessionCategories)
            .Where(rs => rs.Id == id)
            .OrderBy(rs => rs.Title);
    }
}
