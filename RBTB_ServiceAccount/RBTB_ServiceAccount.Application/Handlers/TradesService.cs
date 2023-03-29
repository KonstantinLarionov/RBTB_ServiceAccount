using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Application.Handlers;
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

    public BaseResponse<Trades> AddTrade(Trades trade)
    {
        _repositoryTrades.Create(trade);

        return new BaseResponse<Trades>
        {
            Data = trade
        };
    }

    public BaseResponse<bool> DeleteTrade(Trades trade)
    {
        _repositoryTrades.Remove(trade);
        
        if (trade == null)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = $"Trade {trade} delete"
            };
        }
        
        return new BaseResponse<bool>
        {
            IsSuccess = true
        };
    }

    public BaseResponse<bool> UpdateTrade(Trades trade)

    { 
        _repositoryTrades.Update(trade);

        if (trade == null)
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
}
