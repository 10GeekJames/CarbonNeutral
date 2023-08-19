namespace WskCore.Entities;
public class GameGetByGridIdByUserIdFullSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetByGridIdByUserIdFullSpec(Guid gameGridId, Guid knownUserId)
    {
        Query
            .Include(rs => rs.GameGrids)
                .ThenInclude(rs => rs.GameGridInstances.Where(rs=>rs.KnownUserId == knownUserId))
            .Where(rs => rs.GameGrids.Any(rs=>rs.Id == gameGridId && rs.GameGridInstances.Any(rs=>rs.KnownUserId == knownUserId)))
                .OrderBy(rs => rs.Title)
        ;
    }
}
