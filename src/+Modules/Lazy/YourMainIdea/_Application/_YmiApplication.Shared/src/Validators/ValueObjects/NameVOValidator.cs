namespace YmiApplication.Shared.Validators;
public class NameVOValidator : AbstractValidator<NameVOViewModel>
{
    public NameVOValidator()
    {
        RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .Length(1, 40)
            ;
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<NameVOViewModel>.CreateWithOptions((NameVOViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
