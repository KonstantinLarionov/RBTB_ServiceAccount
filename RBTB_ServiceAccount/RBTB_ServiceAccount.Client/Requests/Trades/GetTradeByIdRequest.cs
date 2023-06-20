using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Trades
{
    public class GetTradeByIdRequest : BaseRequest
    {
        public GetTradeByIdRequest( Guid tradeId )
        {
            TradeId = tradeId;
        }

        public Guid TradeId { get; set; }

        internal override string EndPoint => $"trades/{TradeId}";

        internal override RequestMethod Method => RequestMethod.GET;
    }
}