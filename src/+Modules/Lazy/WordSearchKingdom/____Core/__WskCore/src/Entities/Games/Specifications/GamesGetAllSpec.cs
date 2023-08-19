namespace WskCore.Entities;
public class GamesGetAllSpec : Specification<Game>
{
    public GamesGetAllSpec(Guid knownUserId, bool userOnly = true)
    {
        Query
            .Include(rs => rs.HiddenWords)
            .Include(rs => rs.GameTags)
            .Include(rs => rs.GameCategories);            
            
       
    }
}
