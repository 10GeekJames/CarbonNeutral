namespace AccountModuleCore.Entities;
public class KnownBusinessGetByIdSpec : Specification<KnownBusiness>, ISingleResultSpecification<KnownBusiness>
{
    public KnownBusinessGetByIdSpec(Guid id)
    {
        Query
            .Include(rs => rs.KnownBusinessProfiles)                
            .Where(rs => rs.Id == id)
            
            ;
    }
}
