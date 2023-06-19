using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Username { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid RefferalFrom { get; set; }
    }
}