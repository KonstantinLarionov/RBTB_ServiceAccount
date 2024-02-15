using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;
using RBTB_ServiceAccount.Application.Domains.Abstractions.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Trades
{
    public class GetTradesRequest : IRequest<GetTradesResponse>
    {
        public Guid? UserId { get; set; }

        public OrderType? OrderType { get; set; }

        public Side? Side { get; set; }

        public string? Symbol { get; set; }

        public OrderStatus? OrderStatus { get; set; }
        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
        public SortEnum? Sort { get; set; }
    }
}