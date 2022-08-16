using Trainings.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainings.Api.Application.Responses
{
    public class GetTrainingsResponse
    {
        public IEnumerable<Training> Trainings { get; set; }
    }
}
