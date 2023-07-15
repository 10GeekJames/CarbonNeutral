namespace YmiApplication.Data.Interfaces;

public interface IYmiSeedScript
{
    Task PopulateYmiTestData(IServiceProvider serviceProvider);
}