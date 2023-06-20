using RBTB_ServiceAccount.Client.Abstractions.Enums;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Positions
{
    public class GetPositionsRequest : BaseRequest
    {
        public GetPositionsRequest( Guid? userId, Side? side, PositionStatus? positionStatus, string symbol )
        {
            UserId = userId;
            Side = side;
            PositionStatus = positionStatus;
            Symbol = symbol;
        }

        public Guid? UserId { get; set; }

        public Side? Side { get; set; }

        public PositionStatus? PositionStatus { get; set; }

        public string Symbol { get; set; }

        internal override string EndPoint => "positions";

        internal override RequestMethod Method => RequestMethod.GET;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.AddSimpleStructIfNotNull( "userId", UserId );
                res.AddEnumIfNotNull( "side", Side );
                res.AddEnumIfNotNull( "positionStatus", PositionStatus );
                res.Add( "symbol", Symbol );

                return res;
            }
        }
    }
}