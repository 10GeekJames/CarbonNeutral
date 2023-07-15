namespace AccountModuleCore.TestData.Entities;
public static class KnownAccountTestData {
    
    public readonly static KnownAccount JamesAccount;
    public readonly static KnownAccount KpAccount;

    public readonly static IEnumerable<KnownAccount> AllKnownAccounts;

    static KnownAccountTestData() {
        JamesAccount = new("10geek", "10geekjames@gmail.com");
        KpAccount = new ("kp", "vreyes.s.a@gmail.com");
        
        AllKnownAccounts = new List<KnownAccount> {
            JamesAccount,
            KpAccount
        }
        .AsReadOnly();
    }
}
