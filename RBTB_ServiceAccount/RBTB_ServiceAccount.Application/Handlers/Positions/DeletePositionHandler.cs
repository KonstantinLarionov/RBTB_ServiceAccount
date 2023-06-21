using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Positions;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;
using RBTB_ServiceAccount.Application.Inerfaces;
using RBTB_ServiceAccount.Application.Abstractions.Entities;

namespace RBTB_ServiceAccount.Application.Handlers.Positions;

public class DeletePositionHandler : IRequestHandler<DeletePositionRequest, DeletePositionResponse>
{
    private readonly IRepository<PositionEntity> _repositoryPositions;

    public DeletePositionHandler( IRepository<PositionEntity> repositoryPositions )
    {
        _repositoryPositions = repositoryPositions;
    }

    public async Task<DeletePositionResponse> Handle( DeletePositionRequest request, CancellationToken cancellationToken )
    {
        var deletePosition = _repositoryPositions.Remove( request.PositionId );
        if ( deletePosition == 0 )
        {
            return new DeletePositionResponse() { Success = false };
        }

        return new DeletePositionResponse();
    }
}
