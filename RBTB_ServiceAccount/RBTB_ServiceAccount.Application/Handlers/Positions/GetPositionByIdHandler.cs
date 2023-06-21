using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Positions;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;
using RBTB_ServiceAccount.Application.Inerfaces;
using RBTB_ServiceAccount.Application.Abstractions.Entities;

namespace RBTB_ServiceAccount.Application.Handlers.Positions;

public class GetPositionByIdHandler : IRequestHandler<GetPositionByIdRequest, GetPositionByIdResponse>
{
    private readonly IRepository<PositionEntity> _repositoryPositions;

    public GetPositionByIdHandler( IRepository<PositionEntity> repositoryPositions )
    {
        _repositoryPositions = repositoryPositions;
    }

    public async Task<GetPositionByIdResponse> Handle( GetPositionByIdRequest request, CancellationToken cancellationToken )
    {
        var position = _repositoryPositions.FindById( request.PositionId );

        if ( position != null )
        {
            return new GetPositionByIdResponse() { Success = false };
        }

        return new GetPositionByIdResponse() { Data = position };
    }
}