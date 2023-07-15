namespace AccountModuleCore.TestData.Entities;
public static class KnownUserTestData {
    
    public readonly static Guid JamesUserId = new ("00000c7a-8b1e-4b7a-9a8b-2b1e8f0d7a8b");
    public readonly static Guid KpUserId = new ("11111c7a-8b1e-4b7a-9a8b-2b1e8f0d7a8b");
    
    public readonly static KnownUser JamesUser;
    public readonly static KnownUser KpUser;

    public readonly static IEnumerable<KnownUser> AllKnownUsers;

    static KnownUserTestData() {
        JamesUser = new(JamesUserId);
        KpUser = new (KpUserId);
        
        AllKnownUsers = new List<KnownUser> {
            JamesUser,
            KpUser
        }
        .AsReadOnly();
    }
}
