namespace AccountModuleCore.Specifications;
public class KnownAccountGetAllSpec : Specification<KnownAccount>
{
    public KnownAccountGetAllSpec()
    {
        Query
            .AsNoTracking()
            ;
    }
}
