﻿using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Abstractions.Enums;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Positions
{
    public class CreatePositionRequest : BaseRequest
    {
        public CreatePositionRequest( Guid userId, 
            Guid tradesId, 
            decimal price, 
            string symbol, 
            decimal count, 
            Side side, 
            PositionStatus positionStatus, 
            DateTime createdDate )
        {
            UserId = userId;
            TradesId = tradesId;
            Price = price;
            Symbol = symbol;
            Count = count;
            Side = side;
            PositionStatus = positionStatus;
            CreatedDate = createdDate;
        }

        public Guid UserId { get; set; }

        public Guid TradesId { get; set; }

        public decimal Price { get; set; }

        public string Symbol { get; set; }

        public decimal Count { get; set; }

        public Side Side { get; set; }

        public PositionStatus PositionStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        internal override string EndPoint => "positions/create";

        internal override RequestMethod Method => RequestMethod.POST;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.AddSimpleStruct( "userId", UserId );
                res.AddSimpleStruct( "tradesId", TradesId );
                res.AddDecimal( "price", Price );
                res.Add( "symbol", Symbol );
                res.AddDecimal( "count", Count );
                res.AddEnum( "side", Side );
                res.AddEnum( "positionStatus", PositionStatus );
                res.AddDateTime( "createdDate", CreatedDate );
                return res;
            }
        }
    }
}