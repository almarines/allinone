using Trainings.Api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainings.Api.Application.Queries
{
    public class GetTrainingByIdQuery : IRequest<GetTrainingResponse>
    {
        public int Id { get; set; }
    }
}
