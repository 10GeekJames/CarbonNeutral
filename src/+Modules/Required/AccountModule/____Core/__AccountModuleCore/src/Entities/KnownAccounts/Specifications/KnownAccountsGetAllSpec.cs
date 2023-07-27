namespace AccountModuleCore.Specifications;
public class KnownAccountsGetAllSpec : Specification<KnownAccount>
{
    public KnownAccountsGetAllSpec()
    {
        Query
            .AsNoTracking()
            ;
    }
}
