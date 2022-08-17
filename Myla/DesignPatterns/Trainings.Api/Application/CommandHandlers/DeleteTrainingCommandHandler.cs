using Trainings.Api.Application.Commands;
using Trainings.Api.Application.Responses;
using Trainings.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Trainings.Api.Application.CommandHandlers
{
    public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, DeleteTrainingResponse>
    {

        private readonly ITrainingRepository _trainingRepository;

        public DeleteTrainingCommandHandler(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }


        public async Task<DeleteTrainingResponse> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            var result = _trainingRepository.DeleteTrainingById(request.Id);
            return await Task.FromResult(new DeleteTrainingResponse { IsDeleted = result });
        }

    }
}
