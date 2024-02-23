using CustomValidationWebApplication.Model;
using FluentValidation;
using FluentValidation.Validators;

namespace CustomValidationWebApplication.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FullName)
           .NotEmpty().WithMessage("Full name is required.")
           .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address.");

            //RuleFor(x => x.Age)
            //    .Custom((age, context) =>
            //    {
            //        if (age < 18)
            //        {
            //            context.AddFailure("The Age too young. Age must be between 18 and 100");
            //        }
            //        else if (age > 100)
            //        {
            //            context.AddFailure("The Age too old. Age must be between 18 and 100");
            //        }
            //    });

            RuleFor(x => x.Age)
               .SetValidator(new AgeValidator<Customer>());
        }
    }
    public class AgeValidator<T> : PropertyValidator<T, int>
    {
        
        public override string Name => "AgeValidator";
        public override bool IsValid(ValidationContext<T> context, int age)
        {
            if (age < 18)
            {
                context.AddFailure("The Age too young. Age must be between 18 and 100");
            }
            else if (age > 100)
            {
                context.AddFailure("The Age too old. Age must be between 18 and 100");
            }

            return true;

        }

    }
}
