namespace WskCore.Entities;
public class GameGetLatestGameGridSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetLatestGameGridSpec(Guid gameId)
    {
        Query
            .Include(rs => rs.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .Include(rs => rs.GameGrids)
            .OrderBy(rs=>rs.GameGrids.OrderByDescending(rs=>rs.CreatedOn).FirstOrDefault().CreatedOn)            
        ;
    }
}
