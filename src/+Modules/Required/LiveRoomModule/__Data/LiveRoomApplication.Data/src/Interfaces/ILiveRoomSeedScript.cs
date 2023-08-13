namespace LiveRoomApplication.Data.Interfaces;

public interface ILiveRoomSeedScript
{
    Task PopulateLiveRoomTestData(IServiceProvider serviceProvider);
}