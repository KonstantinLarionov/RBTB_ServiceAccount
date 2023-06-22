using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Positions;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;
using RBTB_ServiceAccount.Application.Inerfaces;
using RBTB_ServiceAccount.Application.Abstractions.Entities;

namespace RBTB_ServiceAccount.Application.Handlers.Positions;

public class GetPositionsHandler : IRequestHandler<GetPositionsRequest, GetPositionsResponse>
{
    private readonly IRepository<PositionEntity> _repositoryPositions;

    public GetPositionsHandler( IRepository<PositionEntity> repositoryPositions )
    {
        _repositoryPositions = repositoryPositions;
    }

    public async Task<GetPositionsResponse> Handle( GetPositionsRequest request, CancellationToken cancellationToken )
    {
        var positions = _repositoryPositions.Get();

        if ( !positions.Any() )
        {
            return new GetPositionsResponse();
        }

        if ( !string.IsNullOrEmpty(request.Symbol) )
        {
            positions = positions.Where( p => p.Symbol == request.Symbol );
        }

        if ( request.PositionStatus != null )
        {
            positions = positions.Where( p => p.PositionStatus == request.PositionStatus );
        }

        if ( request.Side != null )
        {
            positions = positions.Where( p => p.Side == request.Side );
        }

        if ( request.UserId != null )
        {
            positions = positions.Where( p => p.UserId == request.UserId );
        }

        return new GetPositionsResponse() { Data = positions.ToArray() };
    }
}
