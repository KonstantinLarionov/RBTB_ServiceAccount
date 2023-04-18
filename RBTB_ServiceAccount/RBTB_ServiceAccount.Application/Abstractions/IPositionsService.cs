using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Abstractions
{
    public interface IPositionsService
    {
        BaseResponse<Positions> GetPosition(Guid id);

        BaseResponse<Guid> AddPosition(AddPositionRequest request);

        BaseResponse<bool> DeletePosition(Guid positionId);

        BaseResponse<bool> UpdatePosition(Positions position);

        BaseResponse<List<Positions>> GetPositionByUserId(Guid userId);

        BaseResponse<Positions> GetPositionBySymbol(Guid userId, string symbol);

        BaseResponse<List<Positions>> GetTradesByUserId(Guid userId);

        BaseResponse<List<Positions>> GetPositionByTradesId(Guid tradesId);

        BaseResponse<List<Positions>> GetTradesByUserIdAndSymbol(Guid userId, string symbol, GetPositionsBySymbolRequest request);
    }
}
