namespace WskCore.Entities;
public class GameGetByIdSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetByIdSpec(Guid id)
    {
        Query
            .Where(rs => rs.Id == id)
            .OrderBy(rs => rs.Title);
    }
}
