using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Positions;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;
using RBTB_ServiceAccount.Database.Entities;
using RBTB_ServiceAccount.Database.Repositories;

namespace RBTB_ServiceAccount.Application.Handlers.Positions;

public class CreatePositionHandler : IRequestHandler<CreatePositionRequest, CreatePositionResponse>
{
    private readonly IRepository<PositionEntity> _repositoryPositions;

    public CreatePositionHandler( IRepository<PositionEntity> repositoryPositions )
    {
        _repositoryPositions = repositoryPositions;
    }

    public async Task<CreatePositionResponse> Handle( CreatePositionRequest request, CancellationToken cancellationToken )
    {
        var position = new PositionEntity()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Symbol = request.Symbol,
            Side = request.Side,
            CreatedDate = request.CreatedDate,
            PositionStatus = request.PositionStatus,
            Price = request.Price,
            TradesId = request.TradesId
        };

        var createPosition = _repositoryPositions.Create( position );
        if ( createPosition == 0 )
        {
            return new CreatePositionResponse() { Success = false };
        }

        return new CreatePositionResponse();
    }
}
