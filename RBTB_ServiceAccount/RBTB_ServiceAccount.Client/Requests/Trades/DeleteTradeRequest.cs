using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Trades
{
    public class DeleteTradeRequest : BaseRequest
    {
        public DeleteTradeRequest( Guid tradeId )
        {
            TradeId = tradeId;
        }

        public Guid TradeId { get; set; }

        internal override string EndPoint => $"trades/delete/{TradeId}";

        internal override RequestMethod Method => RequestMethod.DELETE;
    }
}