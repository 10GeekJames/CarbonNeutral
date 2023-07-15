namespace AccountModuleCore.TestData.Entities;

public static class KnownAccountProfileTestData {
    
    public readonly static Guid JamesKnownAccountProfileId = new Guid("00000c7a-0000-4b7a-9a8b-2b1e8f0d7a8b");
    public readonly static Guid KpKnownAccountProfileId = new Guid("11111c7a-1111-4b7a-9a8b-2b1e8f0d7a8b");
    
    public readonly static KnownAccountProfile JamesKnownAccountProfile;
    public readonly static KnownAccountProfile KpKnownAccountProfile;

    public readonly static IEnumerable<KnownAccountProfile> AllKnownAccountProfiles;

    static KnownAccountProfileTestData() {
        JamesKnownAccountProfile = new(JamesKnownAccountProfileId, "James");
        KpKnownAccountProfile = new (KpKnownAccountProfileId, "Kp");
        
        AllKnownAccountProfiles = new List<KnownAccountProfile> {
            JamesKnownAccountProfile,
            KpKnownAccountProfile
        }
        .AsReadOnly();
    }
}
