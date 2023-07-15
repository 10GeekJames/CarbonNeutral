namespace AccountModuleClientServiceLoader
{
    public static class AccountModuleDataServiceFactoryExtension
    {
        public static void AddAccountModuleHttpDataService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAccountModuleDataService, AccountModuleHttpDataService>();
        }
    }
}