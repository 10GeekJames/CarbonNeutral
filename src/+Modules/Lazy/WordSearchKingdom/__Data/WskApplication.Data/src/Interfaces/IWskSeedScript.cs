namespace WskApplication.Data.Interfaces;

public interface IWskSeedScript
{
    Task PopulateWskTestData(IServiceProvider serviceProvider);
}