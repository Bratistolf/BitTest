using Bit.Api.Domain.Models.Team;
using FluentValidation;

namespace Bit.Api.Helpers.Validators
{
    public class TeamUpdateValidator : AbstractValidator<TeamUpdateDto>
    {
        public TeamUpdateValidator()
        {
            RuleFor(x => x.TeamName).NotEmpty();
        }
    }
}
