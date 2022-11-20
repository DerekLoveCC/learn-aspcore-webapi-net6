using FluentValidation;
using learn_aspcore_webapi_net6.Dtos;

namespace learn_aspcore_webapi_net6.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}