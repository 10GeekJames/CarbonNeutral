namespace AccountModuleCore.Entities;
public class KnownUserGetByEmailAddressSpec : Specification<KnownUser>, ISingleResultSpecification
{
    public KnownUserGetByEmailAddressSpec(string emailAddress)
    {
        Query
            .Where(s => s.EmailAddress == emailAddress)
            .AsNoTracking()
            ;
    }
}
