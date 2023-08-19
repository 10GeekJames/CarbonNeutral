
namespace LiveRoomCore.UnitTests;

public class LiveRoomSessionConstructorTests
{
    [Fact]
    public void BasicLiveRoomSessionWithValidValues()
    {
        var _reason = "because we should be able to create a basic LiveRoomSession provided valid values";

        // Given I have LiveRoomSession start data
        var height = 25;
        var width = 25;
        var wordsToHide = new List<HiddenWord> { new("Sally"), new("Billy"), new("Larry"), new("Franky"), new("George") }.AsReadOnly();
        var liveRoomSessionDifficulty = LiveRoomSessionDifficulties.Easy;
        var liveRoomSessionCategories = new List<LiveRoomSessionCategory> { new("Shared"), new("Home"), new("School") }.AsReadOnly();
        var liveRoomSessionTags = new List<LiveRoomSessionTag> { new("Fiction"), new("Adventure"), new("Action") }.AsReadOnly();

        // When I create a LiveRoomSession
        var liveRoomSession = new LiveRoomSession("abc", height, width, wordsToHide, liveRoomSessionDifficulty, liveRoomSessionCategories, liveRoomSessionTags);

        // print the char[][] array to the console
        var gridArray = liveRoomSession.LiveRoomSessionGrid.RowCellDataArray;
        liveRoomSession.LiveRoomSessionGrid.RowCellData.Should().NotBeNullOrWhiteSpace(_reason);

        for (int row = 0; row < liveRoomSession.LiveRoomSessionGrid.Height; row++)
        {
            for (int col = 0; col < liveRoomSession.LiveRoomSessionGrid.Width; col++)
            {
                Console.Write(gridArray[row, col] + " ");
            }
            Console.WriteLine();            
        }

        // Then I should have a LiveRoomSession
        liveRoomSession.Should().NotBeNull(_reason);

        // And the LiveRoomSession should have the start data
        liveRoomSession.LiveRoomSessionDifficulty.Should().Be(liveRoomSessionDifficulty, _reason);
        liveRoomSession.LiveRoomSessionCategories.Count().Should().BeGreaterThan(0, _reason);
        liveRoomSession.LiveRoomSessionTags.Count().Should().BeGreaterThan(0, _reason);

        // And the liveRoomSession should have a valid grid
        liveRoomSession.LiveRoomSessionGrid.Should().NotBeNull(_reason);
        liveRoomSession.LiveRoomSessionGrid.Height.Should().Be(height, _reason);
        liveRoomSession.LiveRoomSessionGrid.Width.Should().Be(width, _reason);
        liveRoomSession.LiveRoomSessionGrid.RowCellData.Length.Should().BeGreaterThan(0, _reason);
    }
}