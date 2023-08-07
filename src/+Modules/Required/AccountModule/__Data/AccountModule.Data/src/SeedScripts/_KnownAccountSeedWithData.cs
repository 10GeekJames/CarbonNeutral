namespace AccountModule.Data.SeedScripts;
public class KnownAccountSeedWithData : IAccountModuleSeedScript
{
    public async Task PopulateAccountModuleTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<KnownAccountSeedWithData>>();
        using var dbContext =
                new AccountModuleDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<AccountModuleDbContext>>(
                        ), mediator);
        
        foreach (var knownAccount in KnownAccountTestData.AllKnownAccounts)
        {
            logger?.LogInformation("I was here ;)");
            /* if (!dbContext.KnownAccounts.AsEnumerable().Any(rs => knownAccount.Isbn.Equals(rs.Isbn)))
            {
                dbContext.KnownAccounts.Add(knownAccount);
                logger?.LogInformation("{knownAccount.Title} was created in the database.", knownAccount.Title);
            }
            else
            {
                logger?.LogInformation("{knownAccount.Title} already exist in the database.", knownAccount.Title);
            } */
            await dbContext.SaveChangesAsync();
        }
    }
}
