using RBTB_ServiceAccount.Application.Domains.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Requests
{
    public class AddPositionsRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TradesId { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public Side Side { get; set; }
        public string Symbol { get; set; }
        public OrderStatus PositionsStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
