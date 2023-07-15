namespace YmiApplication.Shared.Validators;
public class MemberInMembershipValidator : AbstractValidator<MemberInMembershipViewModel>
{
    public MemberInMembershipValidator()
    {
        
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<MemberInMembershipViewModel>.CreateWithOptions((MemberInMembershipViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
