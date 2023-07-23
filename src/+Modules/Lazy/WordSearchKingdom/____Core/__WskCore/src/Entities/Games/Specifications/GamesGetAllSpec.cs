namespace WskCore.Entities;
public class GamesGetAllSpec : Specification<Game>
{
    public GamesGetAllSpec()
    {
        Query
            .Include(rs => rs.GameGrid.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .OrderBy(rs => rs.Title);
    }
}
