using RBTB_ServiceAccount.Application.Domains.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Requests
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid RefferalFrom { get; set; }
        public string RefferalCode { get; set; }
    }
}
