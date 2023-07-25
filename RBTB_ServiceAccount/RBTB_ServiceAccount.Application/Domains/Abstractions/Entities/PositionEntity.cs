using RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Abstractions.Entities;

public class PositionEntity
{
    public Guid Id { get; set; }

    public UserEntity User { get; set; }

    public Guid UserId { get; set; }

    public TradeEntity Trade { get; set; }

    public Guid TradeId { get; set; }

    public decimal Price { get; set; }

    public string Symbol { get; set; }

    public decimal Count { get; set; }

    public Side Side { get; set; }

    public PositionStatus PositionStatus { get; set; }

    public DateTime CreatedDate { get; set; }
}