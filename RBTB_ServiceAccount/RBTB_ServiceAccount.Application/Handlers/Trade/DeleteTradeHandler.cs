using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Trades;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Trade;

public class DeleteTradeHandler : IRequestHandler<DeleteTradeRequest, DeleteTradeResponse>
{
    private readonly IRepository<TradeEntity> _repositoryTrades;

    public DeleteTradeHandler( IRepository<TradeEntity> repositoryTrades )
    {
        _repositoryTrades = repositoryTrades;
    }

    public async Task<DeleteTradeResponse> Handle( DeleteTradeRequest request, CancellationToken cancellationToken )
    {
        var deleteTrade = _repositoryTrades.Remove( request.TradeId );
        if ( deleteTrade == 0 )
        {
            return new DeleteTradeResponse() { Success = false };
        }

        return new DeleteTradeResponse();
    }
}
