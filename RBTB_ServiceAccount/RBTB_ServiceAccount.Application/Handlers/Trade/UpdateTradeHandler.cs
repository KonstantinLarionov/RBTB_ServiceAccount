using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Trades;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Trade;

public class UpdateTradeHandler : IRequestHandler<UpdateTradeRequest, UpdateTradeResponse>
{
    private readonly IRepository<TradeEntity> _repositoryTrades;

    public UpdateTradeHandler( IRepository<TradeEntity> repositoryTrades )
    {
        _repositoryTrades = repositoryTrades;
    }

    public async Task<UpdateTradeResponse> Handle( UpdateTradeRequest request, CancellationToken cancellationToken )
    {
        var trade = new TradeEntity()
        {
            Id = request.Id,
            UserId = request.UserId,
            Symbol = request.Symbol,
            Side = request.Side,
            CreatedDate = request.CreatedDate,
            Price = request.Price,
            OrderStatus = request.OrderStatus,
            OrderType = request.OrderType,
            TimeInForce = request.TimeInForce
        };

        var updateTrade = _repositoryTrades.Update( trade );
        if ( updateTrade == 0 )
        {
            return new UpdateTradeResponse() { Success = false };
        }

        return new UpdateTradeResponse() { Data = trade };
    }
}