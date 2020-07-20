using Bit.WebApp.Models;
using FluentValidation;

namespace Bit.WebApp.Helpers.Validators
{
    public class PlayerValidator : AbstractValidator<PlayerModel>
    {
        public PlayerValidator()
        {
            var messageForName = "Имя не может быть пустым.";
            var messageForSurname = "Фамилия не может быть пустой.";
            var messageForBirthday = "Выберите дату рождения.";

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(messageForName)
                .NotNull().WithMessage(messageForName);
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(messageForSurname)
                .NotNull().WithMessage(messageForSurname);
            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage(messageForBirthday)
                .NotNull().WithMessage(messageForBirthday);
            RuleFor(x => x.Gender)
                .Must(x => x == "Мужской" || x == "Женский");
            RuleFor(x => x.Country)
                .Must(x => x == "Россия" || x == "США" || x == "Италия");
        }
    }
}
