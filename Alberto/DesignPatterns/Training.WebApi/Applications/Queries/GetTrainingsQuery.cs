using MediatR;
using Trainings.WebApi.Applications.Responses;

namespace Trainings.WebApi.Applications.Queries;

public class GetTrainingsQuery : IRequest<GetTrainingsResponses>
{
}
