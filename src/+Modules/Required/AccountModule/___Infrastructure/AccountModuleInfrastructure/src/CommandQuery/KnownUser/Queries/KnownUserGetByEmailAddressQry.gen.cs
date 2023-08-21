// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownUserGetByEmailAddressQry : IRequest<KnownUser>
{
    public string EmailAddress { get; set; }
    private KnownUserGetByEmailAddressQry()
    { }
    public KnownUserGetByEmailAddressQry(string emailAddress)
    {
        EmailAddress = Guard.Against.NullOrEmpty(emailAddress);
    }
}
