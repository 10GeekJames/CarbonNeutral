// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownAccountAddCmd : IRequest<KnownAccount>
{
    public string EmailAddress { get; set; }
    public string AliasName { get; set; }
    public KnownAccountAddCmd() { }
    public KnownAccountAddCmd(string aliasName, string emailAddress)
    {
        AliasName = Guard.Against.NullOrEmpty(aliasName, nameof(aliasName));
        EmailAddress = Guard.Against.NullOrEmpty(emailAddress, nameof(emailAddress));
    }
}
