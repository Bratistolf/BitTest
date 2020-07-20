using Bit.WebApp.Models;
using FluentValidation;
using FluentValidation.Results;
using System.Security.Cryptography.X509Certificates;

namespace Bit.WebApp.Helpers.Validators
{
    public class CreateEditValidator : AbstractValidator<PlayerCreateEditViewModel>
    {
        public CreateEditValidator()
        {
            var messageForTeamName = "Название команды не может быть пустым.";

            When(x => x.IsNewTeam, () => {
                RuleFor(x => x.NewTeamName)
                .NotEmpty().WithMessage(messageForTeamName)
                .NotNull().WithMessage(messageForTeamName);
            });
        }
    }
}
