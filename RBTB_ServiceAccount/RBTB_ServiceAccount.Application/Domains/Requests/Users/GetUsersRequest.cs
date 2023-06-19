using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Users
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
    }
}