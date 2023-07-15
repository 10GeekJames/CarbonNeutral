namespace AccountModuleCore.Entities;
public class KnownBusinessGetByIdSpec : Specification<KnownBusiness>, ISingleResultSpecification
{
    public KnownBusinessGetByIdSpec(Guid id)
    {
        Query
            .Include(rs => rs.KnownBusinessProfiles)                
            .Where(rs => rs.Id == id)
            
            ;
    }
}
