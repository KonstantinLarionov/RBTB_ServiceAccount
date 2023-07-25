using RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Abstractions.Entities;

public class TradeEntity
{
    public Guid Id { get; set; }

    public UserEntity User { get; set; }

    public Guid UserId { get; set; }

    public decimal Price { get; set; }

    public decimal Count { get; set; }

    public OrderType OrderType { get; set; }

    public Side Side { get; set; }

    public string Symbol { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public TimeInForce TimeInForce { get; set; }

    public DateTime CreatedDate { get; set; }
}