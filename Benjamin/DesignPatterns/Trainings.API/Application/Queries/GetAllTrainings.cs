using MediatR;
using Trainings.API.Application.Responses;

namespace Trainings.API.Application.Queries
{
    public class GetAllTrainings: IRequest<GetTrainingsResponse>
    {
    }
}
