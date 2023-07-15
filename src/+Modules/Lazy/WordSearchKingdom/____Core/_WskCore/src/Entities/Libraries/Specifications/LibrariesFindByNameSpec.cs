namespace WskCore.Entities;
public class LibrariesFindByNameSpec : Specification<Library>
{
    public LibrariesFindByNameSpec(string searchString)
    {
        Query
            .Where(s => s.Name.Contains(searchString))
            .OrderBy(s => s.Name);
    }
}
