namespace AccountModuleCore.Entities;
public class KnownUserGetByUserIdSpec : Specification<KnownUser>, ISingleResultSpecification
{
    public KnownUserGetByUserIdSpec(Guid userId)
    {
        Query
            .Where(s => s.UserId == userId)
            //.AsNoTracking()
            ;
    }
}
