// ag=yes
namespace WskInfrastructure.CommandQuery; 
public partial class GameCheckWordCoordsCmd : IRequest<Game>
{
    public Guid Id { get; set; }
    public Guid KnownUserId { get; set; } = new Guid("00000000-0000-0000-0000-000000000001");
    public Guid GameGridInstanceId { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }



    public GameCheckWordCoordsCmd() {}
    public GameCheckWordCoordsCmd(Guid id, Guid gameGridInstanceId, int x1, int y1, int x2, int y2)
    {
        Id = id;
        GameGridInstanceId = gameGridInstanceId;
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
}
