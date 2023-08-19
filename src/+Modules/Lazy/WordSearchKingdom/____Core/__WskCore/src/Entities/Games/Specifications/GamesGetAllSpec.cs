namespace WskCore.Entities;
public class GamesGetAllSpec : Specification<Game>
{
    public GamesGetAllSpec(Guid? knownUserId = null, bool userOnly = true)
    {
        Query
            .Include(rs => rs.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories);            
            
        if (userOnly)
        {
            Query
                .Include(rs => rs.GameGrids)
                .ThenInclude(rs=>rs.GameGridInstances)
                    .Where(rs => rs.KnownUserId == knownUserId && rs.GameGrids.Any(rs => rs.GameGridInstances.Any(rs => rs.KnownUserId == knownUserId)))
                .Where(rs => rs.KnownUserId == knownUserId && rs.GameGrids.Any(rs => rs.GameGridInstances.Any(rs => rs.KnownUserId == knownUserId)));
        }
        else
        {
            Query
                .Include(rs => rs.GameGrids)
                .ThenInclude(rs=>rs.GameGridInstances)            
                    .Where(rs => rs.KnownUserId == knownUserId && rs.GameGrids.Any(rs => rs.GameGridInstances.Any(rs => rs.KnownUserId == knownUserId)))
                .Where(rs => rs.KnownUserId == knownUserId && rs.GameGrids.Any(rs => rs.GameGridInstances.Any(rs => rs.KnownUserId == knownUserId)));
        }
        Query
            .OrderBy(rs => rs.Title);
    }
}
