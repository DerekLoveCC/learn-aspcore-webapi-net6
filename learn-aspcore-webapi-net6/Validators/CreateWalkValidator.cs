using FluentValidation;
using learn_aspcore_webapi_net6.Dtos;

namespace learn_aspcore_webapi_net6.Validators
{
    public class CreateWalkValidator : AbstractValidator<CreateWalkDto>
    {
        public CreateWalkValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(10);
        }
    }
}
