using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Users
{
    public class DeleteUserRequest : BaseRequest
    {
        public DeleteUserRequest( Guid userId )
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

        internal override string EndPoint => $"users/delete/{UserId}";

        internal override RequestMethod Method => RequestMethod.DELETE;
    }
}