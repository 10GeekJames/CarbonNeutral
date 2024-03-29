namespace AccountModuleCore.Entities;
public class KnownAccountGetByEmailSpec : Specification<KnownAccount>, ISingleResultSpecification<KnownAccount>
{
    public KnownAccountGetByEmailSpec(string emailAddress)
    {
        Query
            .Include(rs => rs.KnownAccountProfiles)                
            .Where(s => s.EmailAddress == emailAddress)
            .AsNoTracking()
            ;
    }
}
