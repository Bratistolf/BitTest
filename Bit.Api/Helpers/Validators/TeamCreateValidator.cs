using Bit.Api.Domain.Models.Team;
using FluentValidation;

namespace Bit.Api.Helpers.Validators
{
    public class TeamCreateValidator : AbstractValidator<TeamCreateDto>
    {
        public TeamCreateValidator()
        {
            RuleFor(x => x.TeamName).NotEmpty();
        }
    }
}
