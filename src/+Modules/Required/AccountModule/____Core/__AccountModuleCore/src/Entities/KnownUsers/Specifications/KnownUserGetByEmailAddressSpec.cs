namespace AccountModuleCore.Entities;
public class KnownUserGetByEmailAddressSpec : Specification<KnownUser>, ISingleResultSpecification<KnownUser>
{
    public KnownUserGetByEmailAddressSpec(string emailAddress)
    {
        Query
            .Where(s => s.EmailAddress == emailAddress)
            .AsNoTracking()
            ;
    }
}
