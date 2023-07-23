// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameCheckWordCoordsQry : IRequest<Game>
{
    public Guid Id { get; set; }

    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }



    public GameCheckWordCoordsQry() {}
    public GameCheckWordCoordsQry(Guid id, int x1, int y1, int x2, int y2)
    {
        Id = id;
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
}
