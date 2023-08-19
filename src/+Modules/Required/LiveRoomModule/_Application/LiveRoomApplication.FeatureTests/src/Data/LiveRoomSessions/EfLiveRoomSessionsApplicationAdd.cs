namespace LiveRoomApplication.FeatureTests.Data.LiveRoomSessions;
public class EfLiveRoomSessionApplicationAdd : BaseApplicationTestFixture
{
    [Fact]
    public async Task AddLiveRoomSession()
    {

        var result = await _dataService.LiveRoomSessionsGetAllAsync(new LiveRoomSessionsGetAllQry());
        result!.Count.Should().Be(0, "because we haven't added any liveRoomSessions yet");

        var cmd = new LiveRoomSessionAddCmd(LiveRoomSessionLiveRoomTestData.LiveRoomSessionAlfradoTheGreat);
        await _dataService.LiveRoomSessionAddAsync(cmd);

        var qry = new LiveRoomSessionsGetAllQry();
        result = (await _dataService.LiveRoomSessionsGetAllAsync(qry));
        var resultFirst = result!.FirstOrDefault();
        var resultFirstCopy = resultFirst?.LiveRoomSessionCopies.FirstOrDefault();

        result.Should().NotBeNull("because we just added a liveRoomSession");
        resultFirst!.LiveRoomSessionCopies.Count.Should().Be(1, "because we added a single liveRoomSession");
        // test more cool stuff
    }
}
