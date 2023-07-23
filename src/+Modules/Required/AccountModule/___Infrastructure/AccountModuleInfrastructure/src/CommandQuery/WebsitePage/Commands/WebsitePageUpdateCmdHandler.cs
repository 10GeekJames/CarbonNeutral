namespace AccountModuleInfrastructure.CommandQuery; 
public class WebsitePageUpdateCmdHandler : IRequestHandler<WebsitePageUpdateCmd, KnownBusinessWebsite>
{
    private IRepository<KnownBusinessWebsite> _repository;
    public WebsitePageUpdateCmdHandler(IRepository<KnownBusinessWebsite> repository)
    {
        _repository = repository;
    }
    public async Task<KnownBusinessWebsite> Handle(WebsitePageUpdateCmd cmd, CancellationToken cancellationToken)
    {
        var existingWebsiteSpec = new WebsitePageGetByIdSpec(cmd.WebsitePage.Id);
        var knownBusinessWebsite = await _repository.FirstOrDefaultAsync(existingWebsiteSpec, cancellationToken);
        var existingWebsitePage = knownBusinessWebsite?.WebsitePages.FirstOrDefault();
        if (existingWebsitePage != null)
        {
            cmd.WebsitePage.CopyPropertiesTo(existingWebsitePage);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        if (knownBusinessWebsite != null) return knownBusinessWebsite;
        return knownBusinessWebsite!;
    }
}