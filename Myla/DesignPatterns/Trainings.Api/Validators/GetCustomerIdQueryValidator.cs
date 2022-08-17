using Trainings.Api.Application.Commands;
using Trainings.Api.Application.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainings.Api.Application.Validators
{
    public class GetTrainingIdQueryValidator : AbstractValidator<GetTrainingByIdQuery>
    {
        public GetTrainingIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }

    public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
    {
        public CreateTrainingCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().NotNull().WithMessage("Company Name length should be mor than 4");


            RuleFor(c => c.Name).NotEmpty();

        }
    }
}
