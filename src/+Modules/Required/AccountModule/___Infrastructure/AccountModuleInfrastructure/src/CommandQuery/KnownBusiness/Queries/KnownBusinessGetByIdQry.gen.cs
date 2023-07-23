// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessGetByIdQry : IRequest<KnownBusiness>
{
    [Required]
    public Guid Id { get; set; }
    private KnownBusinessGetByIdQry() { }
    public KnownBusinessGetByIdQry(Guid id)
    {
        Id = id;
    }
}
