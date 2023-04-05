using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Database.Abstractions;
using System.Diagnostics;

namespace RBTB_ServiceAccount.Application.Services;
public class PositionsService : IPositionsService
{
    private IRepository<Positions> _repositoryPositions;

    public PositionsService(IRepository<Positions> Positions)
    {
        _repositoryPositions = Positions;
    }

    public BaseResponse<Positions> GetPositions(Guid id)
    {
        var trade = _repositoryPositions.FindById(id);
        if (trade == null)
        {
            return new BaseResponse<Positions>
            {
                IsSuccess = false,
                ErrorMessage = $"Positions with id {id} not found"
            };
        }
        return new BaseResponse<Positions>
        {
            Data = position
        };
    }

    public BaseResponse<Guid> AddPosition (AddPositionRequest request)
    {
        var trade = new Position
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

        var positionsUpdateResult = _repositoryPositions.Create(position);

        if (positionUpdateResult == 0)
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
        var tradeDeleteResult = _repositoryPositions.FindById(positionId);

        if (tradeDeleteResult != null)
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
        var positionUpdateResult = _repositoryPositions.Update(positionId);

        if (positionsUpdateResult == 0)
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
        var trades = _repositoryPositions.Get().Where(p => p.UserId == userId).ToList();

        return new BaseResponse<List<Positions>>
        {
            Data = positions
        };
    }

    public BaseResponse<Positions> GetPositionBySymbol(Guid userId, string symbol)
    {
        var positionGetSymbolResult = _repositoryPositions.Get().Where(p => p.UserId == userId && p.Symbol == symbol).FirstOrDefault();
        if (positionGetSymbolResult == null)
        {
            return new BaseResponse<Positions>
            {
                IsSuccess = false,
                ErrorMessage = $"Position with userId {userId} and symbol {symbol} not found"
            };
        }
        return new BaseResponse<Wallet>
        {
            Data = positionGetSymbolResult
        };
    }

    public BaseResponse<List<Positions>> GetTradesByUserId(Guid userId)
    {
        var trades = _repositoryPositions.Get().Where(p => p.UserId == userId).ToList();

        return new BaseResponse<List<Positions>>
        {
            Data = positions
        };
    }
}
