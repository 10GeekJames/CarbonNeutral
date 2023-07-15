
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
        var game = new Game(height, width, wordsToHide, gameDifficulty, gameCategories, gameTags);

        // print the char[][] array to the console
        var gridArray = game.GameGrid.ToStringArray();
        for (int row = 0; row < gridArray.Length; row++)
        {
            for (int col = 0; col < gridArray[row].Length; col++)
            {
                Console.Write(gridArray[row][col] + " ");
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
        game.GameGrid.Height.Should().Be(height, _reason);
        game.GameGrid.Width.Should().Be(width, _reason);
        game.GameGrid.RowCells.Count().Should().BeGreaterThan(0, _reason);
    }
}