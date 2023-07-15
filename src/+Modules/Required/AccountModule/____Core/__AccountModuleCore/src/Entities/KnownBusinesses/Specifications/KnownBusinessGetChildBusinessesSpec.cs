namespace AccountModuleCore.Entities;
public class KnownBusinessGetChildBusinessesSpec : Specification<KnownBusiness>
{
    public KnownBusinessGetChildBusinessesSpec(Guid id)
    {
        Query
            .Include(rs => rs.ChildBusinesses)
            .Where(rs => rs.Id == id)
            
            ;
    }
}
