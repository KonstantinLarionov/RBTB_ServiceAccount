using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Users
{
    public class CreateUserRequest : BaseRequest
    {
        public CreateUserRequest( string username, string login, string password, DateTime createdDate, Guid refferalFrom )
        {
            Username = username;
            Login = login;
            Password = password;
            CreatedDate = createdDate;
            RefferalFrom = refferalFrom;
        }

        public string Username { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid RefferalFrom { get; set; }

        internal override string EndPoint => "users/create";

        internal override RequestMethod Method => RequestMethod.POST;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.Add( "username", Username );
                res.Add( "login", Login );
                res.Add( "password", Password );
                res.AddSimpleStruct( "createdDate", CreatedDate );
                res.AddSimpleStruct( "refferalFrom", RefferalFrom );

                return res;
            }
        }
    }
}