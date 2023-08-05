namespace WskCore.Entities;
public class GameGetByIdSpec : Specification<Game>, ISingleResultSpecification<Game>
{
    public GameGetByIdSpec(Guid id)
    {
        Query
            .Include(rs=>rs.GameGrid)
                .ThenInclude(rs => rs.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .Where(rs => rs.Id == id)
            .OrderBy(rs => rs.Title);
    }
}
