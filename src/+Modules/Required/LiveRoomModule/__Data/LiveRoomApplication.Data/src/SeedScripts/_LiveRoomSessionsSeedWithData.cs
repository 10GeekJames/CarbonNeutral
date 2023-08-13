namespace LiveRoomApplication.Data.SeedScripts;
public class LiveRoomSessionsSeedWithData : ILiveRoomSeedScript
{
    public async Task PopulateLiveRoomTestData(IServiceProvider serviceProvider)
    {
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        var logger = serviceProvider.GetRequiredService<ILogger<LiveRoomSessionsSeedWithData>>();
        using var dbContext =
                new LiveRoomDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<LiveRoomDbContext>>(
                        ), mediator);
        
        foreach (var liveRoomSession in LiveRoomSessionTestData.AllLiveRoomSessions)
        {
            if (!dbContext.LiveRoomSessions.AsEnumerable().Any(rs => liveRoomSession.Id.Equals(rs.Id)))
            {
                //liveRoomSession.
                dbContext.LiveRoomSessions.Add(liveRoomSession);
                logger?.LogInformation($"{liveRoomSession.Title} was created in the database.", liveRoomSession.Title);
            }
            else
            {
                logger?.LogInformation($"{liveRoomSession.Title} already exist in the database.", liveRoomSession.Title);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
