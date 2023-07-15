namespace AccountModuleCore.Entities;
public class WebsitePageGetByIdSpec : Specification<KnownBusinessWebsite>, ISingleResultSpecification
{
    public WebsitePageGetByIdSpec(Guid id)
    {
        Query
            .Include(rs => rs.WebsitePages.Where(rs=>rs.Id == id))            
            
            ;
    }
}
