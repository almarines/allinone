using Trainings.Api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainings.Api.Application.Commands
{
    public class CreateTrainingCommand : IRequest<CreateTrainingResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
