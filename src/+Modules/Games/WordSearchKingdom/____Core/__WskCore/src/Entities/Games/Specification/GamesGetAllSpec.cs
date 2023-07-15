namespace WskCore.Entities;
public class GamesGetAllSpec : Specification<Game>
{
    public GamesGetAllSpec()
    {
        Query
            .OrderBy(s => s.Title);
    }
}
