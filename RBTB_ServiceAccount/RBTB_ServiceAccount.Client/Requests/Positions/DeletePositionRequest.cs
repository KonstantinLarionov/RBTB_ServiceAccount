using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Positions
{
    public class DeletePositionRequest : BaseRequest
    {
        public DeletePositionRequest( Guid positionId )
        {
            PositionId = positionId;
        }

        public Guid PositionId { get; set; }

        internal override string EndPoint => $"positions/delete/{PositionId}";

        internal override RequestMethod Method => RequestMethod.DELETE;
    }
}