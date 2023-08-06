namespace WskCore.Entities;
public class GamesGetAllSpec : Specification<Game>
{
    public GamesGetAllSpec(Guid knownUserId)
    {
        Query
            .Include(rs => rs.GameGrid.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .Where(rs=>rs.KnownUserId == knownUserId)
            .OrderBy(rs => rs.Title);
    }
}
