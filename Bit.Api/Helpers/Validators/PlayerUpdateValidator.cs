using Bit.Api.Domain.Models;
using FluentValidation;

namespace Bit.Api.Helpers.Validators
{
    public class PlayerUpdateValidator : AbstractValidator<PlayerUpdateDto>
    {
        public PlayerUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Surname)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Gender)
                .Must(x => x == "Мужской" || x == "Женский");
            RuleFor(x => x.Country)
                .Must(x => x == "Россия" || x == "США" || x == "Италия");
        }
    }
}
