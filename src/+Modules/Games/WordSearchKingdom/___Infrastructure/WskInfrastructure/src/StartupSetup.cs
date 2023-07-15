namespace WskInfrastructure;
public static class StartupSetup

{
    public static void AddWskDbContext(this IServiceCollection services, string connectionString) =>

        services.AddDbContext<WskDbContext>(options =>
            options.UseSqlite(connectionString, b => b.MigrationsAssembly("WskApplication.Data")));

    public static void AddWskInMemoryDbContext(this IServiceCollection services, string dbName) =>

        services.AddDbContext<WskDbContext>(options =>
            options.UseInMemoryDatabase(dbName));
}

