namespace AccountModule.Data.SeedScripts;
public class KnownAccountsSeedWithData : IWskSeedScript
{
    public async Task PopulateWskTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<KnownAccountSeedWithData>>();
        using var dbContext =
                new WskDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<WskDbContext>>(
                        ), mediator);
        
        foreach (var knownAccount in KnownAccountTestData.AllKnownAccounts)
        {
            if (!dbContext.KnownAccounts.AsEnumerable().Any(rs => knownAccount.Isbn.Equals(rs.Isbn)))
            {
                dbContext.KnownAccounts.Add(knownAccount);
                logger?.LogInformation("{knownAccount.Title} was created in the database.", knownAccount.Title);
            }
            else
            {
                logger?.LogInformation("{knownAccount.Title} already exist in the database.", knownAccount.Title);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
