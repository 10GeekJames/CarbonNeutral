namespace WskApplication.Data.SeedScripts;
public class WskGamesSeedWithData : IWskSeedScript
{
    public async Task PopulateWskTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<WskGamesSeedWithData>>();
        using var dbContext =
                new WskDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<WskDbContext>>(
                        ), mediator);
        
        foreach (var game in WskGameTestData.AllGames)
        {
            if (!dbContext.Games.AsEnumerable().Any(rs => game.Id.Equals(rs.Id)))
            {
                dbContext.Games.Add(game);
                logger?.LogInformation($"{game.Title} was created in the database.", game.Title);
            }
            else
            {
                logger?.LogInformation($"{game.Title} already exist in the database.", game.Title);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
