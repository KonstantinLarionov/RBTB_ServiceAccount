using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Users
{
    public class GetUserByIdRequest : BaseRequest
    {
        public GetUserByIdRequest( Guid userId )
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

        internal override string EndPoint => $"users/{UserId}";

        internal override RequestMethod Method => RequestMethod.GET;
    }
}