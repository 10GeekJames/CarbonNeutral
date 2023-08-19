namespace WskCore.Entities;
public class GameGetByGridIdSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetByGridIdSpec(Guid gameGridId)
    {
        Query
            .Include(rs => rs.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .Where(rs => rs.GameGrids.Any(rs => rs.Id == gameGridId))
            .OrderBy(rs => rs.Title);
    }
}
