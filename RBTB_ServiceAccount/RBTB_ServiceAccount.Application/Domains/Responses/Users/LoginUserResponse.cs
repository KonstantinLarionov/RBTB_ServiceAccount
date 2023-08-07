using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceAccount.Application.Domains.Responses.Users
{
    public class LoginUserResponse : BaseResponse<Guid>
    {
        public string Token { get; set; }
    }
}
