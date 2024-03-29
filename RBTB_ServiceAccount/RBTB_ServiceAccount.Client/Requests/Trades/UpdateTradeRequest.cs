﻿using RBTB_ServiceAccount.Client.Abstractions.Enums;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Trades
{
    public class UpdateTradeRequest : BaseRequest
    {
        public UpdateTradeRequest( Guid id, Guid userId, decimal price, decimal count, OrderType orderType, Side side, string symbol, OrderStatus orderStatus, TimeInForce timeInForce, DateTime createdDate )
        {
            Id = id;
            UserId = userId;
            Price = price;
            Count = count;
            OrderType = orderType;
            Side = side;
            Symbol = symbol;
            OrderStatus = orderStatus;
            TimeInForce = timeInForce;
            CreatedDate = createdDate;
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public decimal Price { get; set; }

        public decimal Count { get; set; }

        public OrderType OrderType { get; set; }

        public Side Side { get; set; }

        public string Symbol { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public TimeInForce TimeInForce { get; set; }

        public DateTime CreatedDate { get; set; }

        internal override string EndPoint => "trades/update";

        internal override RequestMethod Method => RequestMethod.PUT;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.AddSimpleStruct( "id", Id );
                res.AddSimpleStruct( "userId", UserId );
                res.AddDecimal( "price", Price );
                res.AddDecimal( "count", Count );
                res.AddEnum( "orderType", OrderType );
                res.AddEnum( "side", Side );
                res.Add( "symbol", Symbol );
                res.AddEnum( "orderStatus", OrderStatus );
                res.AddEnum( "timeInForce", TimeInForce );
                res.AddDateTime( "createdDate", CreatedDate );

                return res;
            }
        }
    }
}