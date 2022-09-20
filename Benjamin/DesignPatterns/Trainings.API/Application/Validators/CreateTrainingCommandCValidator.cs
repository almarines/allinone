using FluentValidation;
using Trainings.API.Application.Commands;

namespace Trainings.API.Application.Validators
{

    public class CreateTrainingCommandCValidator : AbstractValidator<CreateTrainingCommand>
    {
        public CreateTrainingCommandCValidator()
        {
            RuleFor(command => command.Name).NotEmpty().MinimumLength(4)
                .WithMessage("Company length should be more than 4 characters");

            RuleFor(c => c.Id).NotEmpty();

        }
    }
}
