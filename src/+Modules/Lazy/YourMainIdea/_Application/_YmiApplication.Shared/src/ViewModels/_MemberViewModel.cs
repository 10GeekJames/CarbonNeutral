namespace YmiApplication.Shared.ViewModels;
public class MemberViewModel : BaseViewModelTracked<Guid>
{
    public NameVOViewModel Name { get; set; } = new();
    public PhysicalAddressVOViewModel Address { get; set; } = new();
    public DigitalAddressVOViewModel? Email { get; set; } = new();
    public DigitalAddressVOViewModel? Phone { get; set; } = new();
    public List<MemberInMembershipViewModel> MemberInMemberships { get; set; } = new();

}
