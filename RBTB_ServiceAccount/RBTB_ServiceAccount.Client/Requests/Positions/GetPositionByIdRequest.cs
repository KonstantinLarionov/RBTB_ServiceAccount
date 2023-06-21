using RBTB_ServiceAccount.Abstractions.Models;
using System.Diagnostics;
using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Positions
{
    public class GetPositionByIdRequest : BaseRequest
    {
        public GetPositionByIdRequest( Guid positionId )
        {
            PositionId = positionId;
        }

        public Guid PositionId { get; set; }

        internal override string EndPoint => $"positions/{PositionId}";

        internal override RequestMethod Method => RequestMethod.GET;
    }
}