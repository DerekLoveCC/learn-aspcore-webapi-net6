using FluentValidation;
using learn_aspcore_webapi_net6.Dtos;

namespace learn_aspcore_webapi_net6.Validators
{
    public class UpdateWalkValidator : AbstractValidator<UpdateWalkDto>
    {
        public UpdateWalkValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Length).GreaterThanOrEqualTo(0);
        }
    }
}
