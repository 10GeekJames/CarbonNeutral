namespace AccountModuleCore.Entities;
public class KnownAccountGetByNameSpec : Specification<KnownAccount>, ISingleResultSpecification<KnownAccount>
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
