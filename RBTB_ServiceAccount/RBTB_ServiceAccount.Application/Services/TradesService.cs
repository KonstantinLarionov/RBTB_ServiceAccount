using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
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

    public BaseResponse<Guid> AddTrade(Trades trade)
    {
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

        if (tradeDeleteResult == null)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = $"Trade {tradeId} delete"
            };
        }
        
        return new BaseResponse<bool>
        {
            IsSuccess = true
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
                ErrorMessage = $"Trade {trade} update"
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

    BaseResponse<Trades> ITradesService.AddTrade(Trades trade)
    {
        throw new NotImplementedException();
    }

    BaseResponse<Trades> ITradesService.DeleteTrade(Guid tradeId)
    {
        throw new NotImplementedException();
    }

    public BaseResponse<Trades> UpdateTrade(Guid id)
    {
        throw new NotImplementedException();
    }
}