namespace LiveRoomApplication.Shared.Validators;
public class LiveRoomSessionValidator : AbstractValidator<LiveRoomSessionViewModel>
{
    public LiveRoomSessionValidator()
    {
        RuleFor(x => x.Title)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .Length(1, 40)
            ;
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<LiveRoomSessionViewModel>.CreateWithOptions((LiveRoomSessionViewModel)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}
