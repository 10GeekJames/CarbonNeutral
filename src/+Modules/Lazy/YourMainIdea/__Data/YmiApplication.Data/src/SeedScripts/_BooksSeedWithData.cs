namespace YmiApplication.Data.SeedScripts;
public class BooksSeedWithData : IYmiSeedScript
{
    public async Task PopulateYmiTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<BooksSeedWithData>>();
        using var dbContext =
                new YmiDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<YmiDbContext>>(
                        ), mediator);
        
        foreach (var book in BookYmiTestData.AllBooks)
        {
            if (!dbContext.Books.AsEnumerable().Any(rs => book.Isbn.Equals(rs.Isbn)))
            {
                dbContext.Books.Add(book);
                logger?.LogInformation("{book.Title} was created in the database.", book.Title);
            }
            else
            {
                logger?.LogInformation("{book.Title} already exist in the database.", book.Title);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
