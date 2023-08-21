// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownAccountGetByNameQry : IRequest<KnownAccount>
{
    [Required]
    public string Name { get; set; }
    private KnownAccountGetByNameQry() { }
    public KnownAccountGetByNameQry(string name)
    {
        Name = name;
    }
}
