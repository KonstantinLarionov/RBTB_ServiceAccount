using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Abstractions
{
    public interface ITradesService
    {
        BaseResponse<Trades> GetTrade(Guid id);

        BaseResponse<Trades> AddTrade(Trades trade);

        BaseResponse<Trades> DeleteTrade(Trades trade);

        BaseResponse<Trades> UpdateTrade(Guid id);

        BaseResponse<Trades> GetTradesByUserId(Guid id);
    }
}
