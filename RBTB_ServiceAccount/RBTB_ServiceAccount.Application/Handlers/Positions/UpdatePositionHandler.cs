using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Positions;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Positions;

public class UpdatePositionHandler : IRequestHandler<UpdatePositionRequest, UpdatePositionResponse>
{
    private readonly IRepository<PositionEntity> _repositoryPositions;

    public UpdatePositionHandler( IRepository<PositionEntity> repositoryPositions )
    {
        _repositoryPositions = repositoryPositions;
    }

    public async Task<UpdatePositionResponse> Handle( UpdatePositionRequest request, CancellationToken cancellationToken )
    {
        var position = new PositionEntity()
        {
            Id = request.Id,
            UserId = request.UserId,
            Symbol = request.Symbol,
            Side = request.Side,
            CreatedDate = request.CreatedDate,
            PositionStatus = request.PositionStatus,
            Price = request.Price,
            TradeId = request.TradesId,
            Count = request.Count
        };

        var updatePosition = _repositoryPositions.Update( position );
        if ( updatePosition == 0 )
        {
            return new UpdatePositionResponse() { Success = false };
        }

        return new UpdatePositionResponse() { Data = position };
    }
}