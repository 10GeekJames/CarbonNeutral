namespace AccountModule.Data.Interfaces;

public interface IAccountModuleSeedScript
{
    Task PopulateAccountModuleTestData(IServiceProvider serviceProvider);
}