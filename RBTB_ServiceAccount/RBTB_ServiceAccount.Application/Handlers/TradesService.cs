using Microsoft.IdentityModel.Tokens;
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
                Success = false,
                ErrorMessage = $"Trade with id {id} not found"
            };
        }
        return new BaseResponse<Trades>
        {
            Data = trade
        };
    }
}