namespace AccountModuleCore.Entities;
public class WebsitePageGetByUrlSpec : Specification<KnownBusinessWebsite>, ISingleResultSpecification<KnownBusinessWebsite>
{
    public WebsitePageGetByUrlSpec(string url)
    {
        Query
            .Include(rs => rs.WebsitePages.Where(rs=>rs.WebPageUrl == url))            
            .AsNoTracking()
            ;
    }
}
