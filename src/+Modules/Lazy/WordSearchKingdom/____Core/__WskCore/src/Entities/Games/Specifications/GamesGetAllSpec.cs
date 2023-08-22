namespace WskCore.Entities;
public class GamesGetAllSpec : Specification<Game>
{
    public GamesGetAllSpec(Guid knownUserId)
    {
        Query
            .Where(rs => rs.KnownUserId == knownUserId)
            .Include(rs => rs.GameGrids.Where(rs => rs.GameGridInstances.Any(rs => rs.KnownUserId == knownUserId)))
                .ThenInclude(rs => rs.GameGridInstances.Where(rs => rs.KnownUserId == knownUserId))
            ;
    }
}

        // Query
        //     .Include(rs => rs.GameGrids.OrderBy(rs=>rs.CreatedOn))
        //         .ThenInclude(rs => rs.GameGridInstances.Where(rs => rs.KnownUserId == knownUserId).OrderBy(rs=>rs.CreatedOn))
        //     .Where(rs => rs.GameGrids.Any(rs => rs.GameGridInstances.Any(rs=>rs.Id == knownUserId)))
        //     ;