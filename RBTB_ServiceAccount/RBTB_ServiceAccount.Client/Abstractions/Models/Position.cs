using RBTB_ServiceAccount.Client.Abstractions.Enums;

namespace RBTB_ServiceAccount.Abstractions.Models;

public class Position
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid TradeId { get; set; }

    public decimal Price { get; set; }

    public string Symbol { get; set; }

    public decimal Count { get; set; }

    public Side Side { get; set; }

    public PositionStatus PositionStatus { get; set; }

    public DateTime CreatedDate { get; set; }
}