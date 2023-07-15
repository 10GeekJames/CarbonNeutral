using System.Reflection;

namespace AccountModule.Data.SeedScripts;
public class RunBaseSeedData
{
    private IMediator? _mediator;
    private ILogger<RunBaseSeedData>? _logger;
    public async Task Initialize(IServiceProvider serviceProvider)
    {
        _mediator = serviceProvider.GetRequiredService<IMediator>();
        _logger = serviceProvider.GetRequiredService<ILogger<RunBaseSeedData>>();
        
        //var booksSeedWithData = new BooksSeedWithData().PopulateAccountModuleTestData(serviceProvider);

        await Task.Yield();
        
        /* foreach (var seedData in Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.IsClass && x.IsAbstract && x.IsSealed)
            .OrderBy(rs => rs.Name))
        {
            _logger.LogInformation("Seeding ... {seedData.Name}", seedData.Name);
            await ((IKnownAccountSeedScript)serviceProvider
                .GetRequiredService(seedData))
                .PopulateAccountModuleTestData(serviceProvider);
        } */
    }
}
