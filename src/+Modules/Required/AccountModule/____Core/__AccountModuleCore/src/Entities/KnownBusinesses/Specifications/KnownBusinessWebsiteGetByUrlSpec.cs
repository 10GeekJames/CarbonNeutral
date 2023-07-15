namespace AccountModuleCore.Entities;
public class KnownBusinessWebsiteGetByUrlSpec : Specification<KnownBusinessWebsite>, ISingleResultSpecification
{
    public KnownBusinessWebsiteGetByUrlSpec(string url)
    {
        Query
            .Include(rs => rs.KnownBusiness)
            .Include(rs => rs.KnownBusinessWebsiteProfile)
            .Include(rs => rs.KnownBusinessWebsiteAliases.Where(rs => rs.Url == url))
            .Include(rs => rs.WebsitePages
                .Where(r => r.WebsiteParentPageId == null)
                )
                .ThenInclude(rs => rs.WebsiteChildPages)
                .ThenInclude(rs => rs.WebsiteChildPages)
                .ThenInclude(rs => rs.WebsiteChildPages)
                .ThenInclude(rs => rs.WebsiteChildPages)            
            .Where(s => s.Url == url || s.KnownBusinessWebsiteAliases.Any(rs => rs.Url == url))
            .AsNoTracking()
            ;
    }
}
