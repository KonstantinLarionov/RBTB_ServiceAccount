using RBTB_ServiceAccount.Client.Common;
using RBTB_ServiceAccount.Client.Extensions;

namespace RBTB_ServiceAccount.Client.Requests.Users
{
    public class UpdateUserRequest : BaseRequest
    {
        public UpdateUserRequest( Guid id, string username, string login, string password, DateTime createdDate, Guid refferalFrom )
        {
            Id = id;
            Username = username;
            Login = login;
            Password = password;
            CreatedDate = createdDate;
            RefferalFrom = refferalFrom;
        }

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid RefferalFrom { get; set; }

        internal override string EndPoint => "users/update";

        internal override RequestMethod Method => RequestMethod.PUT;

        internal override IDictionary<string, string> Properties
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.AddSimpleStruct( "id", Id );
                res.Add( "username", Username );
                res.Add( "login", Login );
                res.Add( "password", Password );
                res.AddDateTime( "createdDate", CreatedDate );
                res.AddSimpleStruct( "refferalFrom", RefferalFrom );

                return res;
            }
        }
    }
}