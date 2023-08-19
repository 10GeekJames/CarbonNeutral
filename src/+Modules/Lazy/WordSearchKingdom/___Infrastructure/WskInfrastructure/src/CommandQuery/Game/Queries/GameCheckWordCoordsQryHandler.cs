// ag=no
namespace WskInfrastructure.CommandQuery;
public partial class GameCheckWordCoordsCmdHandler : IRequestHandler<GameCheckWordCoordsCmd, Game>
{
    private IRepository<Game> _repository;
    public GameCheckWordCoordsCmdHandler(IRepository<Game> repository)
    {
        _repository = repository;
    }

    public async Task<Game> Handle(GameCheckWordCoordsCmd qry, CancellationToken cancellationToken)
    {
        var spec = new GameGetFullGridSpec(qry.GameGridInstanceId);
        var game = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        var rowCells = new List<(int x, int y)>();
        var foundWord = "";

        // check top to bottom
        if (qry.Y1 == qry.Y2)
        {
            if (qry.X2 > qry.X1)
            {
                for (int x = qry.X1; x <= qry.X2; x++)
                {
                    var cell = game.GameGrid.RowCellDataArray[x, qry.Y1];
                    foundWord += cell;
                    rowCells.Add((x, qry.Y1));
                }
            }
        }
        // check bottom to top
        if (qry.Y2 == qry.Y1)
        {
            if (qry.X2 < qry.X1)
            {
                for (int x = qry.X1; x >= qry.X2; x--)
                {
                    var cell = game.GameGrid.RowCellDataArray[x, qry.Y1];
                    foundWord += cell;
                    rowCells.Add((x, qry.Y1));
                }
            }
        }
        // check left to right
        if (qry.X1 == qry.X2)
        {
            if (qry.Y2 > qry.Y1)
            {
                for (int y = qry.Y1; y <= qry.Y2; y++)
                {
                    var cell = game.GameGrid.RowCellDataArray[qry.X1, y];
                    foundWord += cell;
                    rowCells.Add((qry.X1, y));
                }
            }
        }
        // check right to left
        if (qry.X2 == qry.X1)
        {
            if (qry.Y2 < qry.Y1)
            {
                for (int y = qry.Y1; y >= qry.Y2; y--)
                {
                    var cell = game.GameGrid.RowCellDataArray[qry.X1, y];
                    foundWord += cell;
                    rowCells.Add((qry.X1, y));
                }
            }
        }
        // check right down diagonal
        if (qry.X2 > qry.X1 && qry.Y2 > qry.Y1)
        {
            var x = qry.X1;
            var y = qry.Y1;
            while (x <= qry.X2 && y <= qry.Y2)
            {
                var cell = game.GameGrid.RowCellDataArray[x, y];
                foundWord += cell;
                rowCells.Add((x, y));
                x++;
                y++;
            }
        }

        // check right up diagonal
        if (qry.X2 < qry.X1 && qry.Y2 > qry.Y1)
        {
            var x = qry.X1;
            var y = qry.Y1;
            while (x >= qry.X2 && y <= qry.Y2)
            {
                var cell = game.GameGrid.RowCellDataArray[x, y];
                foundWord += cell;
                rowCells.Add((x, y));
                x--;
                y++;
            }
        }

        // check left down diagonal
        if (qry.X2 > qry.X1 && qry.Y2 < qry.Y1)
        {
            var x = qry.X1;
            var y = qry.Y1;
            while (x <= qry.X2 && y >= qry.Y2)
            {
                var cell = game.GameGrid.RowCellDataArray[x, y];
                foundWord += cell;
                rowCells.Add((x, y));
                x++;
                y--;
            }
        }

        // check left up diagonal
        if (qry.X2 < qry.X1 && qry.Y2 < qry.Y1)
        {
            var x = qry.X1;
            var y = qry.Y1;
            while (x >= qry.X2 && y >= qry.Y2)
            {
                var cell = game.GameGrid.RowCellDataArray[x, y];
                foundWord += cell;
                rowCells.Add((x, y));
                x--;
                y--;
            }
        }


        if (game.HiddenWords.Any(rs => rs.Word.ToLower() == foundWord.ToLower()))
        {
            var hiddenWord = game.HiddenWords.FirstOrDefault(rs => rs.Word.ToLower() == foundWord.ToLower());
            hiddenWord.SetFound();
            foreach(var cell in rowCells) {
                game.GameGrid.GameGridInstance.AddColoredCell(cell.x, cell.y);
            }

            // hiddenWord.FoundAt = DateTime.Now;
            // game.Score += hiddenWord.Points;
        }
        await _repository.SaveChangesAsync(cancellationToken);
        return game;
    }
}