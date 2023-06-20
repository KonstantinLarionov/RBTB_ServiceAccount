using RBTB_ServiceAccount.Client.Abstractions.Enums;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Trades
{
    public class GetTradesRequest : BaseRequest
    {
        public GetTradesRequest( Guid? userId, OrderType? orderType, Side? side, string symbol, OrderStatus? orderStatus )
        {
            UserId = userId;
            OrderType = orderType;
            Side = side;
            Symbol = symbol;
            OrderStatus = orderStatus;
        }

        public Guid? UserId { get; set; }

        public OrderType? OrderType { get; set; }

        public Side? Side { get; set; }

        public string Symbol { get; set; }

        public OrderStatus? OrderStatus { get; set; }

        internal override string EndPoint => "trades";

        internal override RequestMethod Method => RequestMethod.GET;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();
                
                res.AddSimpleStructIfNotNull( "userId", UserId );
                res.AddEnumIfNotNull( "orderType", OrderType );
                res.AddEnumIfNotNull( "side", Side );
                res.Add( "symbol", Symbol );
                res.AddEnumIfNotNull( "orderStatus", OrderStatus );

                return res;
            }
        }
    }
}