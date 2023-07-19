// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameCheckWordCoordsQryHandler : IRequestHandler<GameCheckWordCoordsQry, Game>
{
    private IRepository<Game> _repository;
    public GameCheckWordCoordsQryHandler(IRepository<Game> repository) 
    {
        _repository = repository;
    }

    public async Task<Game> Handle(GameCheckWordCoordsQry qry, CancellationToken cancellationToken)
    {
        var spec = new GameGetByIdSpec(qry.Id);
        var game = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        var foundWord = "";
        List<RowCell> rowCells = new List<RowCell>();
        // check horizontal
        if (qry.Y1 == qry.Y2) 
        {
            if (qry.X2 > qry.X1) {
                for (int i = qry.X1; i <= qry.X2; i++) {
                    var cell = game.GameGrid.RowCells.FirstOrDefault(x => x.X == i && x.Y == qry.Y1);
                    foundWord += cell.Letter;
                    rowCells.Add(cell);
                }
            }
        }
        // check backwards horizontal
        if (qry.Y2 == qry.Y1) 
        {
            if (qry.X2 < qry.X1) {
                for (int i = qry.X1; i >= qry.X2; i--) {
                    var cell = game.GameGrid.RowCells.FirstOrDefault(x => x.X == i && x.Y == qry.Y1);
                    foundWord += cell.Letter;
                    rowCells.Add(cell);
                }
            }
        }
        // check vertical
        if (qry.X1 == qry.X2)
        { 
            if (qry.Y2 > qry.Y1) {
                for (int i = qry.Y1; i <= qry.Y2; i++) {
                    var cell = game.GameGrid.RowCells.FirstOrDefault(x => x.X == qry.X1 && x.Y == i);
                    foundWord += cell.Letter;
                    rowCells.Add(cell);
                }
            }
        }
        // check backwards vertical
        if (qry.X2 == qry.X1)
        { 
            if (qry.Y2 < qry.Y1) {
                for (int i = qry.Y1; i >= qry.Y2; i--) {
                    var cell = game.GameGrid.RowCells.FirstOrDefault(x => x.X == qry.X1 && x.Y == i);
                    foundWord += cell.Letter;
                    rowCells.Add(cell);
                }
            }
        }
        // check diagonal
        if (qry.X2 > qry.X1 && qry.Y2 > qry.Y1) {
            var x = qry.X1;
            var y = qry.Y1;
            while (x <= qry.X2 && y <= qry.Y2) {
                var cell = game.GameGrid.RowCells.FirstOrDefault(rowCell => rowCell.X == x && rowCell.Y == y);
                foundWord += cell.Letter;
                rowCells.Add(cell);
                x++;
                y++;
            }
        }

        // check backwards diagonal
        if (qry.X2 < qry.X1 && qry.Y2 > qry.Y1) {
            var x = qry.X1;
            var y = qry.Y1;
            while (x >= qry.X2 && y <= qry.Y2) {
                var cell = game.GameGrid.RowCells.FirstOrDefault(rowCell => rowCell.X == x && rowCell.Y == y);
                foundWord += cell.Letter;
                rowCells.Add(cell);
                x--;
                y++;
            }
        }

        if (game.GameGrid.HiddenWords.Any(rs => rs.Word.ToLower() == foundWord.ToLower())) {
            var hiddenWord = game.GameGrid.HiddenWords.FirstOrDefault(rs => rs.Word.ToLower() == foundWord.ToLower());
            hiddenWord.SetFound();
            foreach (var cell in rowCells) {
                cell.CompleteSet();
            }

            // hiddenWord.FoundAt = DateTime.Now;
            // game.Score += hiddenWord.Points;
        } 
        await _repository.SaveChangesAsync(cancellationToken);
        return game;
    }
}