using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Abstractions
{
    public interface ITradesService
    {
        BaseResponse<Trades> GetTrade(Guid id);

        BaseResponse<Guid> AddTrade(AddTradeRequest request);

        BaseResponse<bool> DeleteTrade(Guid tradeId);

        BaseResponse<bool> UpdateTrade(Trades trade);

        BaseResponse<List<Trades>> GetTradesByUserId(Guid userId);
    }
}
