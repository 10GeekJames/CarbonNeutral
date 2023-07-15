namespace YmiInfrastructure.IntegrationTests.Data;
public abstract class BaseTestFixture
{
    protected YmiDbContext? _dbContext;
    
    protected static DbContextOptions<YmiDbContext> CreateNewContextOptions()
    {
        // Create a fresh service provider, and therefore a fresh
        // InMemory database instance.
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var builder = new DbContextOptionsBuilder<YmiDbContext>();
        builder.UseInMemoryDatabase("YmiDb")
               .UseInternalServiceProvider(serviceProvider);

        return builder.Options;
    }

    protected EfRepository<Library> LibraryRepository()
    {
        var options = CreateNewContextOptions();
        var mockMediator = new Mock<IMediator>();

        _dbContext = new YmiDbContext(options, mockMediator.Object);
        return new EfRepository<Library>(_dbContext);
    }

    protected EfRepository<Book> BookRepository()
    {
        var options = CreateNewContextOptions();
        var mockMediator = new Mock<IMediator>();

        _dbContext = new YmiDbContext(options, mockMediator.Object);
        return new EfRepository<Book>(_dbContext);
    }    
}
