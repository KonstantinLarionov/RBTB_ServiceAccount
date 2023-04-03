using RBTB_ServiceAccount.Application.Domains.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Requests
{
    public class AddTradeRequest
    {
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
}