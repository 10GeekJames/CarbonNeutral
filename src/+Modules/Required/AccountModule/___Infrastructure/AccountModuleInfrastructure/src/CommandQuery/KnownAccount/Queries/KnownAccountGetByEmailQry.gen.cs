// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownAccountGetByEmailQry : IRequest<KnownAccount>
{
    [Required]
    public string EmailAddress { get; set; }
    public KnownAccountGetByEmailQry() { }
    public KnownAccountGetByEmailQry(string emailAddress)
    {
        EmailAddress = emailAddress;
    }
}
