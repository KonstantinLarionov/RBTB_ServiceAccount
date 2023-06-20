using RBTB_ServiceAccount.Client.Common;

namespace RBTB_ServiceAccount.Client.Requests.Users
{
    public class GetUsersRequest : BaseRequest
    {
        internal override string EndPoint => "users";

        internal override RequestMethod Method => RequestMethod.GET;
    }
}