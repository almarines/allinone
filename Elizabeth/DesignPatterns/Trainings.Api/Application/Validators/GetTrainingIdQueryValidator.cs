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
            RuleFor(query => query.TrainingId).NotEmpty();
        }
    }

    public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
    {
        public CreateTrainingCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
