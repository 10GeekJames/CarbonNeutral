
namespace WskCore.UnitTests;

public class GameConstructorTests
{
    [Fact]
    public void BasicGameWithValidValues()
    {
        var _reason = "because we should be able to create a basic wskgame provided valid values";

        // Given I have wskgame start data
        var height = 25;
        var width = 25;
        var wordsToHide = new List<HiddenWord> { new("Sally"), new("Billy"), new("Larry"), new("Franky"), new("George") }.AsReadOnly();
        var gameDifficulty = GameDifficulties.Easy;
        var gameCategories = new List<GameCategory> { new("Shared"), new("Home"), new("School") }.AsReadOnly();
        var gameTags = new List<GameTag> { new("Fiction"), new("Adventure"), new("Action") }.AsReadOnly();

        // When I create a wskgame
        var game = new Game("abc", height, width, gameDifficulty, wordsToHide, gameCategories, gameTags);

        // print the char[][] array to the console
        var gridArray = game.GameGrid.RowCellDataArray;
        game.GameGrid.RowCellData.Should().NotBeNullOrWhiteSpace(_reason);

        for (int row = 0; row < game.Height; row++)
        {
            for (int col = 0; col < game.Width; col++)
            {
                Console.Write(gridArray[row, col] + " ");
            }
            Console.WriteLine();            
        }

        // Then I should have a wskgame
        game.Should().NotBeNull(_reason);

        // And the wskgame should have the start data
        game.GameDifficulty.Should().Be(gameDifficulty, _reason);
        game.GameCategories.Count().Should().BeGreaterThan(0, _reason);
        game.GameTags.Count().Should().BeGreaterThan(0, _reason);

        // And the game should have a valid grid
        game.GameGrid.Should().NotBeNull(_reason);
        game.Height.Should().Be(height, _reason);
        game.Width.Should().Be(width, _reason);
        game.GameGrid.RowCellData.Length.Should().BeGreaterThan(0, _reason);
    }
}