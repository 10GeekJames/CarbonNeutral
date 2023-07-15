namespace WskApplication.FeatureTests.Data.Games;
public class EfGameApplicationAdd : BaseApplicationTestFixture
{
    [Fact]
    public async Task AddGame()
    {

        var result = await _dataService.GamesGetAllAsync(new GamesGetAllQry());
        result!.Count.Should().Be(0, "because we haven't added any games yet");

        var cmd = new GameAddCmd(GameWskTestData.GameAlfradoTheGreat);
        await _dataService.GameAddAsync(cmd);

        var qry = new GamesGetAllQry();
        result = (await _dataService.GamesGetAllAsync(qry));
        var resultFirst = result!.FirstOrDefault();
        var resultFirstCopy = resultFirst?.GameCopies.FirstOrDefault();

        result.Should().NotBeNull("because we just added a game");
        resultFirst!.GameCopies.Count.Should().Be(1, "because we added a single game");
        // test more cool stuff
    }
}
