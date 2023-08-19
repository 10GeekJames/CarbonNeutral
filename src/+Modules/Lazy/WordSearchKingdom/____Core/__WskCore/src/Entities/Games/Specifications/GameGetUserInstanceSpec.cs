namespace WskCore.Entities;
public class GameGetUserInstanceSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetUserInstanceSpec(Guid gameGridInstanceId)
    {
        Query
            .Include(rs => rs.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .Include(rs => rs.GameGrids.Where(rs => rs.GameGridInstances.Any(rs=>rs.Id == gameGridInstanceId)))
                .ThenInclude(rs => rs.GameGridInstances.Where(rs => rs.Id == gameGridInstanceId))
            .Where(rs => rs.GameGrids.Any(rs => rs.GameGridInstances.Any(rs => rs.Id == gameGridInstanceId)))
            .OrderBy(rs => rs.Title);
    }
}
