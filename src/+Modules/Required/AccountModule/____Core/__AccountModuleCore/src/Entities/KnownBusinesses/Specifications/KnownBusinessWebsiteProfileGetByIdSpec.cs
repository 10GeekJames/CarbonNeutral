namespace AccountModuleCore.Entities;
public class KnownBusinessWebsiteProfileGetByIdSpec : Specification<KnownBusinessWebsiteProfile>, ISingleResultSpecification<KnownBusinessWebsiteProfile>
{
    public KnownBusinessWebsiteProfileGetByIdSpec(Guid id)
    {
        Query
            .Where(rs => rs.Id == id)
        ;
    }
}
