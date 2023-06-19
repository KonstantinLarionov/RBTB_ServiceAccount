using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Trades
{
    public class GetTradeByIdRequest : IRequest<GetTradeByIdResponse>
    {
        public Guid TradeId { get; set; }
    }
}