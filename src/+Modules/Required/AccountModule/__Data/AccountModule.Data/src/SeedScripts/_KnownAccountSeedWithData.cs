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

            
            
            await dbContext.SaveChangesAsync();
        }
    }
}
