using Api.RequestModels;
using FluentValidation;

namespace Api.Validators
{
    public class UserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public UserRequestValidator(IHostEnvironment hostEnvironment)
        {
            RuleFor(request => request.Username)
                .NotEmpty().WithMessage("Username is required")
                .Length(6, 30).WithMessage("Username must be between 6 and 30 characters.");

            if (!hostEnvironment.IsDevelopment())
            {
                RuleFor(request => request.Password)
                    .NotEmpty().WithMessage("Password is required")
                    .Length(10, 30).WithMessage("Password must be between 10 and 30 characters.")
                    .Matches(@"[A-Å]").WithMessage("Password must contain at least one uppercase letter.")
                    .Matches(@"\d").WithMessage("Password must contain at least one digit.")
                    .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
            }
        }
    }
}