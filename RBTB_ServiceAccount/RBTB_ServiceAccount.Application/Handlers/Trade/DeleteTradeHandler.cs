using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Trades;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Trade;

public class DeleteTradeHandler : IRequestHandler<DeleteTradeRequest, DeleteTradeResponse>
{
    private readonly IRepository<TradeEntity> _repositoryTrades;
    private readonly IRepository<PositionEntity> _repositoryPositions;

    public DeleteTradeHandler(IRepository<TradeEntity> repositoryTrades, IRepository<PositionEntity> repositoryPositions)
    {
        _repositoryTrades = repositoryTrades;
        _repositoryPositions = repositoryPositions;
    }

    public async Task<DeleteTradeResponse> Handle(DeleteTradeRequest request, CancellationToken cancellationToken)
    {
        var user = _repositoryTrades.Get().Where(t => t.Id == request.TradeId).FirstOrDefault();

        if (user is not null)
        {
            var positions = _repositoryPositions.Get().Where(p => p.UserId == user.Id).ToList();

            if (positions.Any()) 
            {
                foreach(var position in positions)
                {
                    _repositoryPositions.Remove(position.Id);
                }
            }
        }

        var deleteTrade = _repositoryTrades.Remove(request.TradeId);
        if (deleteTrade == 0)
        {
            return new DeleteTradeResponse() { Success = false };
        }

        return new DeleteTradeResponse() { Data = request.TradeId };
    }
}
