namespace WskCore.Entities;
public class GameGetByIdFullSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetByIdFullSpec(Guid gameId)
    {
        Query
            .Include(rs => rs.GameGrids)
                .ThenInclude(rs => rs.GameGridInstances)
            .Where(rs => rs.Id == gameId)
                .OrderBy(rs => rs.Title)
        ;
    }
}
