namespace YmiApplication.Shared.Validators;
public class PhysicalAddressVOValidator : AbstractValidator<PhysicalAddressVOViewModel>
{
    public PhysicalAddressVOValidator()
    {
        RuleFor(x => x.Street1)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .Length(1, 40)
            ;
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<PhysicalAddressVOViewModel>.CreateWithOptions((PhysicalAddressVOViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
