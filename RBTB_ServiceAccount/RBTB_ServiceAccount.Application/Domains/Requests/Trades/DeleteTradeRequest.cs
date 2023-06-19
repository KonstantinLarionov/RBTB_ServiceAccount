using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Trades
{
    public class DeleteTradeRequest : IRequest<DeleteTradeResponse>
    {
        public Guid TradeId { get; set; }
    }
}