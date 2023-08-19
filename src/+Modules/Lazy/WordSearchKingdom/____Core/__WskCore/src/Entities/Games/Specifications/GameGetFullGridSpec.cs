namespace WskCore.Entities;
public class GameGetFullGridSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetFullGridSpec(Guid gameGridInstanceId)
    {
        Query
            .Take(1)
            .Include(rs => rs.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .Include(rs => rs.GameGrids.Where(rs => rs.GameGridInstances.Any(rs=>rs.Id == gameGridInstanceId)))
                .ThenInclude(rs => rs.GameGridInstances.Where(rs => rs.Id == gameGridInstanceId).OrderBy(rs=>rs.CreatedOn))
            .Where(rs => rs.GameGrids.Any(rs => rs.GameGridInstances.Any(rs => rs.Id == gameGridInstanceId)))
            ;
    }
}
