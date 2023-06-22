using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Trades;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Trade;

public class CreateTradeHandler : IRequestHandler<CreateTradeRequest, CreateTradeResponse>
{
    private readonly IRepository<TradeEntity> _repositoryTrades;

    public CreateTradeHandler( IRepository<TradeEntity> repositoryTrades )
    {
        _repositoryTrades = repositoryTrades;
    }

    public async Task<CreateTradeResponse> Handle( CreateTradeRequest request, CancellationToken cancellationToken )
    {
        var trade = new TradeEntity()
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Symbol = request.Symbol,
            Side = request.Side,
            CreatedDate = request.CreatedDate,
            Price = request.Price,
            OrderStatus = request.OrderStatus,
            OrderType = request.OrderType,
            TimeInForce = request.TimeInForce
        };

        var createTrade = _repositoryTrades.Create( trade );
        if ( createTrade == 0 )
        {
            return new CreateTradeResponse() { Success = false };
        }

        return new CreateTradeResponse() { Data = trade.Id };
    }
}
