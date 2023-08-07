namespace AccountModuleInfrastructure
{
	public static class StartupSetup
	{
		public static void AddAccountModuleSqlDbContext(this IServiceCollection services, string connectionString) =>

		services.AddDbContext<AccountModuleDbContext>(options =>
			options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AccountModule.Data")));

		public static void AddAccountModuleSqliteDbContext(this IServiceCollection services, string connectionString) =>

			services.AddDbContext<AccountModuleDbContext>(options =>
				options.UseSqlite(connectionString, b => b.MigrationsAssembly("AccountModule.Data")));

		public static void AddAccountModuleInMemoryDbContext(this IServiceCollection services, string dbName) =>

			services.AddDbContext<AccountModuleDbContext>(options =>
				options.UseInMemoryDatabase(dbName));
	}
}
