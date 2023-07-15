namespace YmiApplication.Data.SeedScripts;
public class LibrariesSeedWithData : IYmiSeedScript
{
    public async Task PopulateYmiTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<BooksSeedWithData>>();

        using var dbContext =
                new YmiDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<YmiDbContext>>(
                        ), mediator);

       
        if (!dbContext.Libraries.Any())
        {
            dbContext.Libraries.AddRange(LibraryYmiTestData.AllLibraries);
            await dbContext.SaveChangesAsync();
            logger?.LogInformation("Seeded All Library Data");
        }

        if (dbContext.Libraries.FirstOrDefault(rs => rs.Name == LibraryYmiTestData.FirstStreetLibraryName) is null)
        {
            dbContext.Libraries.Add(LibraryYmiTestData.FirstStreetLibrary);
            await dbContext.SaveChangesAsync();
            logger?.LogInformation("Seeded Single Library Data");
        }
    }
}
