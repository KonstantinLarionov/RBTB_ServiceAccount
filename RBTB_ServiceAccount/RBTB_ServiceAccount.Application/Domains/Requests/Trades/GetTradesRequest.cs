using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Trades
{
    public class GetTradesRequest : IRequest<GetTradesResponse>
    {
        public Guid? UserId { get; set; }

        public OrderType? OrderType { get; set; }

        public Side? Side { get; set; }

        public string? Symbol { get; set; }

        public OrderStatus? OrderStatus { get; set; }
    }
}