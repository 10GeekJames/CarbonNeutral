namespace WskApplication.Data.SeedScripts;
public class LibrariesSeedWithData : IWskSeedScript
{
    public async Task PopulateWskTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<BooksSeedWithData>>();

        using var dbContext =
                new WskDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<WskDbContext>>(
                        ), mediator);

       
        if (!dbContext.Libraries.Any())
        {
            dbContext.Libraries.AddRange(LibraryWskTestData.AllLibraries);
            await dbContext.SaveChangesAsync();
            logger?.LogInformation("Seeded All Library Data");
        }

        if (dbContext.Libraries.FirstOrDefault(rs => rs.Name == LibraryWskTestData.FirstStreetLibraryName) is null)
        {
            dbContext.Libraries.Add(LibraryWskTestData.FirstStreetLibrary);
            await dbContext.SaveChangesAsync();
            logger?.LogInformation("Seeded Single Library Data");
        }
    }
}
