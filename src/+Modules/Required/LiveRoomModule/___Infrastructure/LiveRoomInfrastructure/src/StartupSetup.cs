namespace LiveRoomInfrastructure;
public static class StartupSetup

{
    public static void AddLiveRoomSqlDbContext(this IServiceCollection services, string connectionString) =>

        services.AddDbContext<LiveRoomDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("LiveRoomApplication.Data")));
    
    public static void AddLiveRoomSqliteDbContext(this IServiceCollection services, string connectionString) =>

        services.AddDbContext<LiveRoomDbContext>(options =>
            options.UseSqlite(connectionString, b => b.MigrationsAssembly("LiveRoomApplication.Data")));

    public static void AddLiveRoomInMemoryDbContext(this IServiceCollection services, string dbName) =>

        services.AddDbContext<LiveRoomDbContext>(options =>
            options.UseInMemoryDatabase(dbName));
}

