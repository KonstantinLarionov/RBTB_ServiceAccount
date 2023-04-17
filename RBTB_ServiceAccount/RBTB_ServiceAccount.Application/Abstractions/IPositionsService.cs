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

        BaseResponse<List<Positions>> GetPositionsByUserId(Guid userId);

        BaseResponse<List<Positions>> GetTradesByUserId(Guid userId);

        BaseResponse<Positions> GetPositionByTradeId(Guid tradeId);

        BaseResponse<List<Positions>> GetPositionsByUserIdAndSymbol(userId symbol);
    }
}
