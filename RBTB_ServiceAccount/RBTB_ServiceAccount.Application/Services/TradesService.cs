using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Application.Services;
public class TradesService : ITradesService
{
    private IRepository<Trades> _repositoryTrades;

    public TradesService(IRepository<Trades> Trades)
    {
        _repositoryTrades = Trades;
    }

    public BaseResponse<Trades> GetTrade(Guid id)
    {
        var trade = _repositoryTrades.FindById(id);
        if (trade == null)
        {
            return new BaseResponse<Trades>
            {
                IsSuccess = false,
                ErrorMessage = $"Trade with id {id} not found"
            };
        }
        return new BaseResponse<Trades>
        {
            Data = trade
        };
    }

    public BaseResponse<Guid> AddTrade(AddTradeRequest request)
    {
        var trade = new Trade
        {
            Id = Guid.NewGuid(),
            Price = request.Price,
            Count = request.Count,
            OrderType = request.OrderType,
            Side = request.Side,
            Symbol = request.Symbol,
            OrderStatus = request.OrderStatus,
            TimeInForce = request.TimeInForce,
            DateTime = request.CreatedDate
        };

        var tradeUpdateResult = _repositoryTrades.Create(trade);

        if (tradeUpdateResult == 0)
        {
            return new BaseResponse<Guid>
            {
                IsSuccess = false,
                ErrorMessage = $"Don`t added trade{trade}"
            };
        }

        return new BaseResponse<Guid>
        {
            Data = trade.Id
        };
    }


    public BaseResponse<bool> DeleteTrade(Guid tradeId)
    {
        var tradeDeleteResult = _repositoryTrades.FindById(tradeId);

        if (tradeDeleteResult != null)
        {
            var removeTradeResult= _repositoryTrades.Remove(tradeDeleteResult);
            if(removeTradeResult != 0) 
            {
                return new BaseResponse<bool>();
            }
        }
  
        return new BaseResponse<bool>
        {
            IsSuccess = false,
            ErrorMessage = $"Trade don`t delete. Trade:{tradeId}"
        };
    }

    public BaseResponse<bool> UpdateTrade(Trades trade)
    { 
        var tradeUpdateResult =  _repositoryTrades.Update(trade);

        if (tradeUpdateResult == 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = $"Trade don`t update. Trade:{trade}"
            };
        }

        return new BaseResponse<bool>
        {
            IsSuccess = true
        };
    }

    public BaseResponse<List<Trades>> GetTradesByUserId(Guid userId)
    {
        var trades = _repositoryTrades.Get().Where(t => t.UserId == userId).ToList();

        return new BaseResponse<List<Trades>>
        {
            Data = trades
        };
    }
} 