namespace AccountModule.Data.SeedScripts;
public class KnownBusinessSeedWithData : IAccountModuleSeedScript
{
    public async Task PopulateAccountModuleTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<KnownBusinessSeedWithData>>();
        using var dbContext =
                new AccountModuleDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<AccountModuleDbContext>>(
                        ), mediator);
        
        foreach (var knownBusiness in KnownBusinessTestData.AllKnownBusinesses)
        {
            logger?.LogInformation("I was also here ;)");
            if (!dbContext.KnownBusinesses.AsEnumerable().Any(rs => knownBusiness.Name.Equals(rs.Name)))
            {
                dbContext.KnownBusinesses.Add(knownBusiness);
                logger?.LogInformation("{knownBusiness.Name} was created in the database.", knownBusiness.Name);
            }
            else
            {
                logger?.LogInformation("{knownBusiness.Name} already exist in the database.", knownBusiness.Name);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
