// using FluentValidation;
// using System.Collections;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using System;
// using System.Linq;
// using AccountModuleApplication.Shared.ViewModels;

// namespace AccountModuleApplication.Shared.Validators
// {
//     public class LiveRoomValidator : AbstractValidator<LiveRoomViewModel>
//     {
//         /// <summary>
//         /// A standard AbstractValidator which contains multiple rules and can be shared with the back end API
//         /// </summary>
//         /// <typeparam name="LiveRoomViewModel"></typeparam>
//         public LiveRoomValidator()
//         {
//             RuleFor(x => x.Name)
//                 .Cascade(CascadeMode.Stop)                
//                 .NotEmpty()
//                 .NotNull()
//                 .Length(1, 40)
//                 .MustAsync(async (value, cancellationToken) => await IsNameUniqueAsync(value))
//                 .WithMessage(LiveRoom => $"Please select another meeting name")
//                 ;

//             /* RuleFor(x => x.AgreeToTerms)
//                 .Cascade(CascadeMode.Stop)                
//                 .NotNull()
//                 .Must(x => x.Equals(true))
//                 .WithMessage(LiveRoom => $"Please agree to terms before continuing")
//                 ; */

//             /* RuleForEach(x => x.OrderDetails)
//                 .SetValidator(new OrderDetailsModelFluentValidator()); */
//         }

//         private async Task<bool> IsNameUniqueAsync(string name)
//         {
//             if(name == null) { name = ""; }
//             // Simulates a long running http call
//             await Task.Delay(2000);
//             return name.ToLower() != "used" && name != "";
//         }
//         public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
//         {
//             var result = await ValidateAsync(ValidationContext<LiveRoomViewModel>.CreateWithOptions((LiveRoomViewModel)model, x => x.IncludeProperties(propertyName)));
//             if (result.IsValid)
//                 return Array.Empty<string>();
//             return result.Errors.Select(e => e.ErrorMessage);
//         };        
//     }
// }
