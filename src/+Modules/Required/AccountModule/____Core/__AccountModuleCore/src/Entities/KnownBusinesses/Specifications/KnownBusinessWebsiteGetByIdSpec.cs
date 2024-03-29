namespace AccountModuleCore.Entities;
public class KnownBusinessWebsiteGetByIdSpec : Specification<KnownBusinessWebsite>, ISingleResultSpecification<KnownBusinessWebsite>
{
    public KnownBusinessWebsiteGetByIdSpec(Guid id)
    {
        Query
            .Include(rs => rs.KnownBusinessWebsiteProfile)
            .Where(rs => rs.Id == id)
        ;
    }
}
