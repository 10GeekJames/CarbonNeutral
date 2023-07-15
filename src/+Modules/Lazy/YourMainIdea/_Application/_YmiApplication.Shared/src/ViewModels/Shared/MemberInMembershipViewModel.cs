namespace YmiApplication.Shared.ViewModels;
public class MemberInMembershipViewModel : BaseViewModelTracked<Guid>
{
    public MemberViewModel Member { get; set; } = new();
    public MembershipViewModel Membership { get; set; } = new();

}
