namespace YmiApplication.Shared.Validators;
public class MembershipValidator : AbstractValidator<MembershipViewModel>
{
    public MembershipValidator()
    {
        RuleFor(x => x.MembershipTitle)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .Length(1, 40)
            ;
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<MembershipViewModel>.CreateWithOptions((MembershipViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
