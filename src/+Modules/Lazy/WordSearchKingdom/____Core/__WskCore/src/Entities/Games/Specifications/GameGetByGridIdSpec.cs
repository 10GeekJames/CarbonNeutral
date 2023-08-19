namespace WskCore.Entities;
public class GameGetByGridIdSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetByGridIdSpec(Guid gameGridId)
    {
        Query
            .Include(rs => rs.HiddenWords)
            .Where(rs => rs.GameGrids.Any(rs => rs.Id == gameGridId))
            .OrderBy(rs => rs.Title);
    }
}
