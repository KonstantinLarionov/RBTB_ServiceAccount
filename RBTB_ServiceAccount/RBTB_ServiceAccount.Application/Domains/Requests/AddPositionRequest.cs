using RBTB_ServiceAccount.Application.Domains.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Requests
{
    public class AddPositionRequest
    {
        public Guid UserId { get; set; }
        public Guid TradesId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public Side Side { get; set; }
        public string Symbol { get; set; }
        public OrderStatus PositionStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
