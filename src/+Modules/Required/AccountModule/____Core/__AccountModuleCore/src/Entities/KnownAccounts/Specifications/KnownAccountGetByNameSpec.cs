namespace AccountModuleCore.Entities;
public class KnownAccountGetByNameSpec : Specification<KnownAccount>, ISingleResultSpecification
{
    public KnownAccountGetByNameSpec(string name)
    {
        Query
            .Include(rs => rs.KnownAccountProfiles)                
            .Where(s => s.Name == name)
            .AsNoTracking()
            ;
    }
}
