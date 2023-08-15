namespace WskCore.Entities;
public class GamesGetAllSpec : Specification<Game>
{
    public GamesGetAllSpec(Guid? knownUserId = null, bool userOnly = true)
    {
        Query
            .Include(rs => rs.GameGrid.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories);

        if (userOnly){
            Query
            .Where(rs=>rs.KnownUserId == knownUserId);
        } else {
            Query
            .Where(rs=>rs.KnownUserId == null);
        }
        Query
            .OrderBy(rs => rs.Title);
    }
}
