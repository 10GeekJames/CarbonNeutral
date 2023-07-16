namespace WskCore.Entities;
public class GameGetByIdSpec : Specification<Game>, ISingleResultSpecification
{
    public GameGetByIdSpec(Guid id)
    {
        Query
            .Include(rs => rs.GameGrid.RowCells)
            .Include(rs => rs.GameGrid.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories)
            .Where(rs => rs.Id == id)
            .OrderBy(rs => rs.Title);
    }
}
