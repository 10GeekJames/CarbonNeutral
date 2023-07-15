namespace YmiApplication.Shared.Validators;
public class LibraryValidator : AbstractValidator<LibraryViewModel>
{
    public LibraryValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .Length(1, 40)
            ;
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<LibraryViewModel>.CreateWithOptions((LibraryViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
