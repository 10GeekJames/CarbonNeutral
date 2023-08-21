namespace WskCore.Entities;
public class GameGetLatestGameGridSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetLatestGameGridSpec(Guid gameId)
    {
        Query
            .Include(rs => rs.GameGrids)
            .Where(rs => rs.Id == gameId)
            .OrderBy(rs => rs.GameGrids.OrderByDescending(rs => rs.CreatedOn).FirstOrDefault().CreatedOn)
        ;
    }
}
