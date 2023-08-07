using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Users
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Password { get; set; }

        public string Login { get; set; }

    }
}
