using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Application.Services;
public class PositionsService : IPositionsService
{
    private IRepository<Positions> _repositoryPositions;

    public PositionsService(IRepository<Positions> Positions)
    {
        _repositoryPositions = Positions;
    }

    public BaseResponse<Positions> GetPosition(Guid id)
    {
        var position = _repositoryPositions.FindById(id);
        if (position == null)
        {
            return new BaseResponse<Positions>
            {
                IsSuccess = false,
                ErrorMessage = $"Position with id {id} not found"
            };
        }
        return new BaseResponse<Positions>
        {
            Data = position
        };
    }

    public BaseResponse<Guid> AddPosition (AddPositionRequest request)
    {
        var position = new Position
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            TradesId = request.TradesId,
            Price = request.Price,
            Count = request.Count,
            Side = request.Side,
            Symbol = request.Symbol,
            PositionStatus = request.PositionStatus,
            DateTime = request.CreatedDate
        };

        var positionsUpdateResult = _repositoryPositions.Create(position);

        if (positionsUpdateResult == 0)
        {
            return new BaseResponse<Guid>
            {
                IsSuccess = false,
                ErrorMessage = $"Don`t added position{position}"
            };
        }

        return new BaseResponse<Guid>
        {
            Data = position.Id
        };
    }


    public BaseResponse<bool> DeletePosition (Guid positionId)
    {
        var positionDeleteResult = _repositoryPositions.FindById(positionId);

        if (positionDeleteResult != null)
        {
            var removePositionResult = _repositoryPositions.Remove(positionDeleteResult);
            if (removePositionResult != 0)
            {
                return new BaseResponse<bool>();
            }
        }

        return new BaseResponse<bool>
        {
            IsSuccess = false,
            ErrorMessage = $"Position don`t delete. Position:{positionId}"
        };
    }

    public BaseResponse<bool> UpdatePosition(Positions position)
    {
        var positionUpdateResult = _repositoryPositions.Update(position);

        if (positionUpdateResult == 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = $"Position don`t update. Positions:{position}"
            };
        }

        return new BaseResponse<bool>
        {
            IsSuccess = true
        };
    }

    public BaseResponse<List<Positions>> GetPositionsByUserId(Guid userId)
    {
        var positions = _repositoryPositions.Get().Where(p => p.UserId == userId).ToList();

        return new BaseResponse<List<Positions>>
        {
            Data = positions
        };
    }


    public BaseResponse<Positions> GetPositionByTradeId(Guid tradeId)
    {
        var positiontradeId = _repositoryPositions.FirstOrDefault(p => p.TradesId == tradeId);

        if (position == null)
        {
            return new BaseResponse<Positions>
            {
                IsSuccess = false,
                ErrorMessage = $"Position with tradeId {tradeId} not found"
            };
        }
        return new BaseResponse<Positions>
        {
            Data = position
        };
    }
}
